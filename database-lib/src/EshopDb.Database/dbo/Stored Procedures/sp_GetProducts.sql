/* Return list of products */
CREATE PROCEDURE [dbo].[sp_GetProducts]
AS
BEGIN
	SELECT 
		[Products].[ID]
		,[Products].[Name]
		,[Products].[ImgUri]
		,[Products].[Price]
		,[Products].[Description]
	FROM [dbo].[Products]
	ORDER BY [Products].[ID]
END