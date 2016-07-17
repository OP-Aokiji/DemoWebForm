using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WN.DataItem;
using WN.ServiceProxy;
using System.IO;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Threading;
using WN.Common;
using WN.WebApp.cm;

namespace WN.WebApp.adminCp.uc
{
    public partial class ucBannerCU : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["admin-login-status"] != null)
            {
                if (!Session["admin-login-status"].Equals("success"))
                    Response.Redirect(Constants.NAVIGATE_DEFAULT_PAGE + "ucLogin");
                else
                {
                    if (Request.QueryString.AllKeys.Contains("img_Id") && Request.QueryString.AllKeys.Contains("crud"))
                    {
                        if (!string.IsNullOrEmpty(Request["img_Id"].ToString()) && !string.IsNullOrEmpty(Request["crud"].ToString()))
                        {
                            try
                            {
                                BannerItem bannerItem = new BannerItem();
                                bannerItem.img_Id = Request["img_Id"].ToString();
                                bannerItem.img_Crud = Constants.WS_QUERY;

                                IBannerProxy proxy = new BannerProxy();
                                DataTable dataResult = (DataTable)proxy.BannerCRUD(bannerItem);
                                if (dataResult.Rows.Count > 0)
                                {
                                    //Load image to imagebox
                                    string imageName = @"~/" + Constants.BANNER_DIR + dataResult.Rows[0]["IMG_NAME"].ToString();
                                    textboxImageName.Text = imageName;
                                    imageView.ImageUrl = imageName;

                                    //textboxImgHeader.Text = dataResult.Rows[0]["IMG_HEADER"].ToString();
                                    //textboxImgText.Text = dataResult.Rows[0]["IMG_TEXT"].ToString();
                                }
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show(ex.Message.ToString(), this);
                            }
                        }
                    }
                }
            }
            else Response.Redirect(Constants.NAVIGATE_DEFAULT_PAGE + "ucLogin");
        }

        protected void buttonSaveData_Click(object sender, EventArgs e)
        {
            try
            {
                string serverPath = string.Empty;
                string filename = string.Empty;
                Bitmap bmpImg = null;

                if (!Request.QueryString.AllKeys.Contains("img_Id") || !Request.QueryString.AllKeys.Contains("crud"))
                {
                    if (fileUploadImage.HasFile)
                    {
                        //check image extension
                        if (ImageUtility.HasImageExtension(fileUploadImage.FileName))
                        {
                            //set server path and file name
                            serverPath = Server.MapPath(@"~/" + Constants.BANNER_DIR + fileUploadImage.FileName);
                            filename = Path.GetFileName(fileUploadImage.FileName);

                            if (filename.Length > 60)
                            {
                                MessageBox.Show("Tên file ảnh bạn upload quá dài, chiều dài tối đa của file ảnh là 60 kí tự !", this);
                                return;
                            }

                            //Resize image
                            bmpImg = ImageUtility.ResizeImage(fileUploadImage.PostedFile.InputStream, 1000, 450);
                            //check server file before upload

                            if (File.Exists(serverPath))
                            {
                                //Genarate new file from old file
                                filename = DateTime.Now.ToString("yyyyMMddHHmmss") + "_" + filename;
                                serverPath = Server.MapPath(@"~/" + Constants.BANNER_DIR + filename);
                            }
                            //Upload file to server
                            //bmpImg.Save(serverPath, ImageFormat.Png);
                            bmpImg.Save(serverPath);

                            //Show image to image view control
                            imageView.ImageUrl = @"~/" + Constants.BANNER_DIR + filename;


                            if (System.IO.File.Exists(serverPath))
                            {
                                BannerItem bannerItem = new BannerItem();
                                bannerItem.img_Name = filename;
                                //bannerItem.img_Header = textboxImgHeader.Text;
                                //bannerItem.img_Text = textboxImgText.Text;
                                bannerItem.img_Crud = Constants.WS_INSERT;

                                IBannerProxy proxy = new BannerProxy();
                                string result = (string)proxy.BannerCRUD(bannerItem);
                                if (result.Equals(Constants.WR_SUCCESS))
                                {
                                   // textboxImgHeader.Text = string.Empty;
                                    //textboxImgText.Text = string.Empty;

                                    MessageBox.Show(MessageBox.SAVE_SUCCESS, this);
                                }
                                //else  if (result.Equals(Constants.WR_EXIST_DATA))
                                   // MessageBox.Show("Category name was existed !", this);
                                else
                                    MessageBox.Show(MessageBox.SAVE_FAILD, this);
                            }
                            else
                            {
                                MessageBox.Show("Hình ảnh không tồn tại trên server !", this);
                            }

                        }
                        else
                        {
                            MessageBox.Show("Xẩy ra lỗi trong quá trình kiểm tra đường dẫn hình ảnh !", this);
                        }

                    }
                    else
                    {
                        MessageBox.Show("Vui lòng chọn hình ảnh !", this);
                    }
                }
                else //Case: Update
                {
                    serverPath = string.Empty;
                    filename = string.Empty;
                    bool isNewImage = false;
                    if (fileUploadImage.HasFile || !string.IsNullOrEmpty(textboxImageName.Text))
                    {
                        //check image extension
                        if (fileUploadImage.HasFile)
                        {
                            if (ImageUtility.HasImageExtension(fileUploadImage.FileName))
                            {
                                serverPath = Server.MapPath(@"~/" + Constants.BANNER_DIR + fileUploadImage.FileName);
                                filename = Path.GetFileName(fileUploadImage.FileName);
                                textboxImageName.Text = @"~/" + Constants.BANNER_DIR + fileUploadImage.FileName;
                                isNewImage = true;
                            }
                            else
                            {
                                MessageBox.Show("Ảnh phải có phần mở rộng là: png, jpg !",  this);
                            }
                        }
                        else
                        {
                            if (ImageUtility.HasImageExtension(textboxImageName.Text))
                            {
                                serverPath = Server.MapPath(textboxImageName.Text);
                                filename = textboxImageName.Text.Split('/')[3]; //based on : @"~/" + Constants.BANNER_DIR
                                isNewImage = false;
                            }
                            else
                            {
                                MessageBox.Show("Ảnh phải có phần mở rộng là: png, jpg !", this);
                            }
                        }

                        if (!string.IsNullOrEmpty(serverPath) && !string.IsNullOrEmpty(filename))
                        {
                            if (isNewImage)
                            {
                                //Resize image
                                bmpImg = ImageUtility.ResizeImage(fileUploadImage.PostedFile.InputStream, 1000, 450);
                                //check server file before upload

                                if (File.Exists(serverPath))
                                {
                                    //Genarate new file from old file
                                    filename = DateTime.Now.ToString("yyyyMMddHHmmss") + "_" + Path.GetFileName(fileUploadImage.FileName);
                                    serverPath = Server.MapPath(@"~/" + Constants.BANNER_DIR + filename);
                                }
                                //Upload file to server
                                //bmpImg.Save(serverPath, ImageFormat.Png);
                                bmpImg.Save(serverPath);

                                //Show image to image view control
                                imageView.ImageUrl = @"~/" + Constants.BANNER_DIR + filename;
                            }

                            if (System.IO.File.Exists(serverPath))
                            {
                                BannerItem bannerItem = new BannerItem();
                                bannerItem.img_Id = Request["img_Id"].ToString();
                                bannerItem.img_Name = filename;
                                //bannerItem.img_Header = textboxImgHeader.Text;
                                //bannerItem.img_Text = textboxImgText.Text;
                                bannerItem.img_Crud = Constants.WS_UPDATE;

                                IBannerProxy proxy = new BannerProxy();
                                string result = (string)proxy.BannerCRUD(bannerItem);
                                if (result.Equals(Constants.WR_SUCCESS))
                                {
                                    //textboxImgHeader.Text = string.Empty;
                                    //textboxImgText.Text = string.Empty;
                                    //textboxImageName.Text = string.Empty;
                                    MessageBox.Show(MessageBox.SAVE_SUCCESS, this);
                                    //Thread.Sleep(500);
                                    //Response.Redirect("Default.aspx?ctr=ucBanner");
                                }
                                //else if (result.Equals(Constants.WR_EXIST_DATA))
                                    //MessageBox.Show("Category name was existed !", this);
                                else
                                    MessageBox.Show(MessageBox.SAVE_FAILD,this);
                            }
                            else
                            {
                                MessageBox.Show("Hình ảnh không tồn tại trên server !",  this);
                            }

                        }
                        else
                        {
                            MessageBox.Show("Xẩy ra lỗi trong quá trình kiểm tra đường dẫn hình ảnh !",  this);
                        }

                    }
                    else
                    {
                        MessageBox.Show("Vui lòng chọn hình ảnh !", this);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(),this);
            }
        }
    }
}