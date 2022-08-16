/* Return one product */
CREATE PROCEDURE [dbo].[sp_GetProduct]
@Id bigint
AS
BEGIN
	SELECT 
		[Products].[ID]
		,[Products].[Name]
		,[Products].[ImgUri]
		,[Products].[Price]
		,[Products].[Description]
	FROM [dbo].[Products]
	WHERE [Products].[ID]=@Id
END