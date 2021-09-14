using Microsoft.EntityFrameworkCore.Migrations;

namespace InstitueMgntDemoApi.Services.Migrations
{
    public partial class ufnGetBranchName : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            string function = @"CREATE FUNCTION dbo.ufnGetBranchName(@BranchId int)
                            RETURNS Varchar(4)   
                            AS
                            -- Returns the stock level for the product.  
                            BEGIN
                                DECLARE @ret Varchar(4);
                                        SELECT @ret = b.BranchCode from Branches b where b.BranchId = @BranchId;
                                        IF(@ret IS NULL)
                                    SET @ret = 'None';
                                        RETURN @ret;
                                        END";
            migrationBuilder.Sql(function);



        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            string function = @"DROP FUNCTION ufnGetBranchName";
            migrationBuilder.Sql(function);
        }
    }
}
