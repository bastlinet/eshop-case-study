/* Return list of filtered products */
CREATE PROCEDURE [dbo].[sp_GetFilteredProducts]
	@Limit int,
	@Offset int
AS
BEGIN
	-- query
	SELECT 
		[Products].[ID]
		,[Products].[Name]
		,[Products].[ImgUri]
		,[Products].[Price]
		,[Products].[Description]
	FROM [dbo].[Products]
	ORDER BY [Products].[ID]
	OFFSET @Offset ROWS 
	FETCH NEXT @Limit ROWS ONLY

	-- filteredcount
	SELECT @@ROWCOUNT

	-- totalcount
	SELECT COUNT(*)
	FROM [dbo].[Products]
END