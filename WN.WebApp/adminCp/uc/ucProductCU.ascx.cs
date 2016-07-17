using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WN.DataItem;
using WN.ServiceProxy;
using System.Drawing;
using System.IO;
using System.Data;
using WN.WebApp.cm;
using WN.Common;

namespace WN.WebApp.adminCp.uc
{
    public partial class ucProductCU : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            CKFinder.FileBrowser _FileBrowser = new CKFinder.FileBrowser();
            _FileBrowser.BasePath = "/ad/js/ckeditor/";
            _FileBrowser.SetupCKEditor(ckeditorProDescription);
            if (Session["admin-login-status"] != null)
            {
                if (Session["admin-login-status"].Equals("success"))
                {
                    if (!IsPostBack)
                    {
                        LoadCategoryLevel2(Constants.RETRIEVE_ALL);

                        if (Request.QueryString.AllKeys.Contains("pro_Id") && Request.QueryString.AllKeys.Contains("crud"))
                        {
                            if (!string.IsNullOrEmpty(Request["pro_Id"].ToString()) && !string.IsNullOrEmpty(Request["crud"].ToString()))
                            {
                                LoadProductImage(Request["pro_Id"].ToString());
                                ProductItem productItem = new ProductItem();
                                productItem.pro_Ws = Constants.WS_QUERY;
                                productItem.pro_Id = Request["pro_Id"].ToString();
                                IProductProxy proxy = new ProductProxy();
                                DataTable dataResult = (DataTable)proxy.ProductCRUD(productItem);
                                textboxProName.Text = dataResult.Rows[0]["PRO_NAME"].ToString();
                                textboxProOldPrice.Text = dataResult.Rows[0]["PRO_OLD_PRICE"].ToString();
                                textboxProPrice.Text = dataResult.Rows[0]["PRO_PRICE"].ToString();
                                ckeditorProDescription.Text = dataResult.Rows[0]["PRO_DESCRIPTION"].ToString();

                                if (dataResult.Rows[0]["PRO_HOME_PAGE_VIEW"].ToString().Equals("True"))
                                    checkBoxHomePage.Checked = true;

                                if (dataResult.Rows[0]["PRO_GENDER"].ToString().Equals("Nam/Nữ"))
                                {
                                    checkboxNam.Checked = true;
                                    checkboxNu.Checked = true;
                                }
                                else if (dataResult.Rows[0]["PRO_GENDER"].ToString().Equals("Nam"))
                                    checkboxNam.Checked = true;
                                else if (dataResult.Rows[0]["PRO_GENDER"].ToString().Equals("Nữ"))
                                    checkboxNu.Checked = true;

                                comboboxCategoryLevel2.Items.FindByValue(dataResult.Rows[0]["CAT_L2_ID"].ToString()).Selected = true;
                            }
                        }
                    }
                }
                else Response.Redirect(Constants.NAVIGATE_DEFAULT_PAGE + "ucLogin");
            }
            else Response.Redirect(Constants.NAVIGATE_DEFAULT_PAGE + "ucLogin");
        }
        private void LoadCategoryLevel2(string cat_L2_Id)
        {
            try
            {
                CategoryLevel2Item categoryLevel2Item = new CategoryLevel2Item();
                categoryLevel2Item.cat_L2_Id = cat_L2_Id;
                categoryLevel2Item.cat_L2_Ws = Constants.WS_QUERY;

                ICategoryLevel2Proxy proxy = new CategoryLevel2Proxy();
                comboboxCategoryLevel2.DataSource = (DataTable)proxy.CategoryLevel2CRUD(categoryLevel2Item);
                comboboxCategoryLevel2.DataValueField = "CAT_L2_ID";
                comboboxCategoryLevel2.DataTextField = "CAT_L2_NAME";
                comboboxCategoryLevel2.DataBind();
                CommonUtility.AddFirstRowDropDownList(comboboxCategoryLevel2, "--Select--", "000");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), this);
            }
        }
       
        private void LoadProductImage(string pro_Id)
        {
            try
            {
                ProductImageItem productImageItem = new ProductImageItem();
                productImageItem.pro_Id = pro_Id;
                productImageItem.img_Ws = Constants.WS_QUERY;

                IProductImageProxy proxy = new ProductImageProxy();
                repeaterImageList.DataSource = proxy.ProductImageCRUD(productImageItem);
                repeaterImageList.DataBind();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), this);
            }
        }
        protected void buttonUploadImage_Click(object sender, EventArgs e)
        {
            #region--##-------------Variable------------##--
            string serverPath = string.Empty;
            string filename = string.Empty;
            Bitmap bmpImg = null;
            #endregion--##-------------Variable------------##--

            #region --##-------------Insert/Update Product------------##--
            if (fileUploadImage.HasFile)
            {
                string pro_Id = "0";
                if (ImageUtility.HasImageExtension(fileUploadImage.FileName))
                {
                    //set server path and file name
                    serverPath = Server.MapPath(@"~/" + Constants.PRODUCT_DIR + fileUploadImage.FileName);
                    filename = Path.GetFileName(fileUploadImage.FileName);

                    if (filename.Length > 60)
                    {
                        MessageBox.Show("Tên file ảnh bạn upload quá dài, chiều dài tối đa của file ảnh là 60 kí tự !", this);
                        return;
                    }

                    //Resize image
                    bmpImg = ImageUtility.ResizeImage(fileUploadImage.PostedFile.InputStream, 400, 400);
                    //check server file before upload

                    if (File.Exists(serverPath))
                    {
                        //Genarate new file from old file
                        filename = DateTime.Now.ToString("yyyyMMddHHmmss") + "_" + filename;
                        serverPath = Server.MapPath(@"~/" + Constants.PRODUCT_DIR + filename);
                    }
                    //Upload file to server
                    //bmpImg.Save(serverPath, ImageFormat.Png);
                    bmpImg.Save(serverPath);

                    //Show image to image view control

                    if (System.IO.File.Exists(serverPath))
                    {
                        ProductImageItem productImageItem = new ProductImageItem();
                        if (Request.QueryString.AllKeys.Contains("pro_Id") && Request.QueryString.AllKeys.Contains("crud"))
                            productImageItem.pro_Id = pro_Id = Request["pro_Id"].ToString();
                        else
                            productImageItem.pro_Id =  pro_Id = "0";

                        productImageItem.img_Name = filename;
                        productImageItem.img_Description = "";
                        productImageItem.img_Ws = Constants.WS_INSERT;

                        IProductImageProxy proxy = new ProductImageProxy();
                        string result = (string)proxy.ProductImageCRUD(productImageItem);
                        if (result.Equals(Constants.WR_SUCCESS))
                        {
                            LoadProductImage(pro_Id);
                        }
                        else
                            MessageBox.Show(MessageBox.SAVE_FAILD, this);
                    }
                    else
                    {
                        MessageBox.Show("Hình ảnh không tồn tại trên server !!!", this);
                    }
                }
                else
                {
                    MessageBox.Show("Ảnh phải có phần mở rộng là: png, jpg !", this);
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn hình ảnh !", this);
            }

            #endregion --##-------------Insert/Update Product------------##--
        }
        protected void repeaterImageList_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            if (e.CommandName.Equals(Constants.DELETE_ITEM))
            {
                try
                {
                    ProductImageItem productImageItem = new ProductImageItem();
                    productImageItem.img_Id = e.CommandArgument.ToString();
                    productImageItem.img_Ws = Constants.WS_DELETE;

                    IProductImageProxy proxy = new ProductImageProxy();
                    string result = (string)proxy.ProductImageCRUD(productImageItem);
                    if (result.Equals(Constants.WR_SUCCESS))
                    {
                        if (!Request.QueryString.AllKeys.Contains("pro_Id") || !Request.QueryString.AllKeys.Contains("crud")) //Insert Case
                            LoadProductImage("0");
                        else //Update Case 
                            LoadProductImage(Request["pro_Id"].ToString());

                        MessageBox.Show(MessageBox.DELETE_SUCCESS, this);
                    }
                    else
                        MessageBox.Show(MessageBox.DELETE_FAILD, this);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString(), this);
                }
            }
            else if (e.CommandName.Equals("UPDATE_ITEM"))
            {
                Response.Redirect(Constants.NAVIGATE_DEFAULT_PAGE + "ucCategoryCU&cat_Id=" + e.CommandArgument.ToString() + "&crud=U");
            }
        }
        protected void buttonSaveData_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textboxProName.Text))
            {
                MessageBox.Show("Bạn chưa nhập tên sản phẩm !!!", this);
                return;
            }
            if (string.IsNullOrEmpty(textboxProPrice.Text))
            {
                MessageBox.Show("Bạn chưa nhập giá sản phẩm !!!", this);
                return;
            }

            if (!checkboxNam.Checked && !checkboxNu.Checked)
            {
                MessageBox.Show("Vui lòng check Nam/Nữ cho sản phẩm !!!", this);
                return;
            }

            ProductItem productItem = new ProductItem();
            productItem.pro_Name = textboxProName.Text;
            productItem.pro_Old_Price = textboxProOldPrice.Text;
            productItem.pro_Price = textboxProPrice.Text;
            productItem.cat_L2_Id = comboboxCategoryLevel2.SelectedValue.ToString();
            productItem.pro_Home_Page = (checkBoxHomePage.Checked) ? true : false;
            productItem.pro_Gender = (checkboxNam.Checked && checkboxNu.Checked) ? "NAM/NU" : (checkboxNam.Checked && !checkboxNu.Checked) ? "NAM":"NU";
            productItem.pro_Description = ckeditorProDescription.Text;

            if (!Request.QueryString.AllKeys.Contains("pro_Id") || !Request.QueryString.AllKeys.Contains("crud"))
            {
                productItem.pro_Ws = Constants.WS_INSERT;
            }
            else
            {
                productItem.pro_Id = Request["pro_Id"].ToString();
                productItem.pro_Ws = Constants.WS_UPDATE;
            }

            if (repeaterImageList.Items.Count <= 0)
            {
                MessageBox.Show("Vui lòng upload hình ảnh cho sản phẩm !", this);
                return;
            }

            IProductProxy proxy = new ProductProxy();
            string result = (string)proxy.ProductCRUD(productItem);
            if (result.Equals(Constants.WR_SUCCESS))
            {
                if (!Request.QueryString.AllKeys.Contains("pro_Id") || !Request.QueryString.AllKeys.Contains("crud"))
                {
                    textboxProName.Text = string.Empty;
                    textboxProPrice.Text = string.Empty;
                    textboxProOldPrice.Text = string.Empty;
                    checkBoxHomePage.Checked = false;
                    ckeditorProDescription.Text = string.Empty;
                    comboboxCategoryLevel2.SelectedIndex = 0;
                    repeaterImageList.DataSource = null;
                    repeaterImageList.DataBind();
                }
                MessageBox.Show(MessageBox.SAVE_SUCCESS, this);
            }
            else
                MessageBox.Show(MessageBox.SAVE_FAILD, this);
        }
    }
}