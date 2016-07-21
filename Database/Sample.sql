ALTER PROC [dbo].[SP_PRODUCT_RETRIEVE]
 @P_PRO_NM NVARCHAR(100)
,@P_CAT_LV1_ID VARCHAR(7)
,@P_CAT_LV2_ID VARCHAR(7)
,@P_UNT_LV1_ID VARCHAR(7)
AS
 BEGIN
  IF @P_PRO_NM IS NULL SET @P_PRO_NM = '';
  IF @P_CAT_LV1_ID IS NULL SET @P_CAT_LV1_ID = '';
  IF @P_CAT_LV2_ID IS NULL SET @P_CAT_LV2_ID = '';
  IF @P_UNT_LV1_ID IS NULL SET @P_UNT_LV1_ID = '';

  DECLARE @V_SQL_QUERY NVARCHAR(MAX) =   'SELECT PRO_ID
            ,PRO_NM
            ,PRO_ALIAS_NM
            ,GNRL.GNRL_CD AS CAT_LV1_ID
            ,DBO.GET_GNRL_NM(CAT_LV1_ID,''CAT1'') CAT_LV1_NM
            ,P.CAT_LV2_ID
            ,CAT2.CAT_LV2_NM
            ,UNT_LV1_ID
            ,DBO.GET_GNRL_NM(UNT_LV1_ID,''UNIT'') UNT_LV1_NM
            ,UNT_LV1_QTY
            ,UNT_LV2_ID
            ,DBO.GET_GNRL_NM(UNT_LV2_ID,''UNIT'') UNT_LV2_NM
            ,UNT_LV2_QTY
            ,UNT_LV3_ID
            ,DBO.GET_GNRL_NM(UNT_LV3_ID,''UNIT'') UNT_LV3_NM
            ,UNT_LV3_QTY
            ,ISNULL(IN_PRICE,0) AS IN_PRICE
            ,ISNULL(PRO_VAT,0) AS PRO_VAT
            ,PRO_FUNC
            ,P.REMARK
            ,PRO_IMG
            ,P.UPDATE_CD
            ,FORMAT(P.UPDATE_TIME,''dd/MM/yyyy HH:mm'') UPDATE_TIME
           FROM TB_PRODUCT P INNER JOIN TB_CAT_LV2 CAT2
           ON P.CAT_LV2_ID = CAT2.CAT_LV2_ID INNER JOIN TB_GNRL_CODE GNRL
           ON CAT2.CAT_LV1_ID = GNRL.GNRL_CD
          WHERE 1 = 1';
  IF @P_PRO_NM <> ''
   SET @V_SQL_QUERY = @V_SQL_QUERY + ' AND (P.PRO_NM LIKE ''%' + @P_PRO_NM +  '%'' OR P.PRO_ALIAS_NM LIKE ''%' + @P_PRO_NM +  '%'')';  

  IF @P_CAT_LV2_ID <> ''
   SET @V_SQL_QUERY = @V_SQL_QUERY + ' AND P.CAT_LV2_ID = ''' + @P_CAT_LV2_ID +  '''';

  IF @P_CAT_LV1_ID <> ''
   SET @V_SQL_QUERY = @V_SQL_QUERY + ' AND GNRL.GNRL_CD = ''' + @P_CAT_LV1_ID +  '''';
  
  IF @P_UNT_LV1_ID <> ''
   SET @V_SQL_QUERY = @V_SQL_QUERY + ' AND (UNT_LV1_ID = ''' + @P_UNT_LV1_ID + ''' OR UNT_LV2_ID = ''' + @P_UNT_LV1_ID + ''' OR UNT_LV3_ID = ''' + @P_UNT_LV1_ID + ''')';

  PRINT @V_SQL_QUERY;

  EXEC(@V_SQL_QUERY);
 END