# deploy DB Windows (.NET Framework) variant
# "C:\Program Files (x86)\Microsoft SQL Server\140\DAC\bin\SqlPackage.exe" /SourceFile:".\database-lib\src\EshopDb.Database\bin\Release\EshopDb.Database.Core.dacpac" /Action:Publish /TargetDatabaseName:EshopDevDb /TargetServerName:"."

# deploy DB Windows (.NET Core) variant
sqlpackage /SourceFile:".\database-lib\src\EshopDb.Database\bin\Release\EshopDb.Database.Core.dacpac" /Action:Publish /TargetDatabaseName:EshopDevDb /TargetServerName:"."