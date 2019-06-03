using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace akaratakapp.Migrations
{
    public partial class DatabaseStandardNames : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Addresses_Cities_City_ID",
                table: "Addresses");

            migrationBuilder.DropForeignKey(
                name: "FK_Addresses_Countries_Country_ID",
                table: "Addresses");

            migrationBuilder.DropForeignKey(
                name: "FK_Cities_Countries_Country_ID",
                table: "Cities");

            migrationBuilder.DropForeignKey(
                name: "FK_Features_Directons_Directon_ID",
                table: "Features");

            migrationBuilder.DropForeignKey(
                name: "FK_Features_Properties_Property_ID",
                table: "Features");

            migrationBuilder.DropForeignKey(
                name: "FK_Listings_Properties_Property_ID",
                table: "Listings");

            migrationBuilder.DropForeignKey(
                name: "FK_Offers_Currencies_Currency_ID",
                table: "Offers");

            migrationBuilder.DropForeignKey(
                name: "FK_Photos_Properties_Property_ID",
                table: "Photos");

            migrationBuilder.DropForeignKey(
                name: "FK_Properties_Addresses_Address_ID",
                table: "Properties");

            migrationBuilder.DropForeignKey(
                name: "FK_Properties_Offers_Offer_ID",
                table: "Properties");

            migrationBuilder.DropForeignKey(
                name: "FK_Properties_SubCategories_SubCategory_ID",
                table: "Properties");

            migrationBuilder.DropForeignKey(
                name: "FK_SubCategories_Categories_Category_ID",
                table: "SubCategories");

            migrationBuilder.DropForeignKey(
                name: "FK_Tags_Features_FeaturesProperty_ID",
                table: "Tags");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SubCategories",
                table: "SubCategories");

            migrationBuilder.DropIndex(
                name: "IX_SubCategories_Category_ID",
                table: "SubCategories");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Properties",
                table: "Properties");

            migrationBuilder.DropIndex(
                name: "IX_Properties_Address_ID",
                table: "Properties");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Photos",
                table: "Photos");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Offers",
                table: "Offers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Listings",
                table: "Listings");

            migrationBuilder.DropIndex(
                name: "IX_Listings_Property_ID",
                table: "Listings");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Directons",
                table: "Directons");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Currencies",
                table: "Currencies");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Countries",
                table: "Countries");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Cities",
                table: "Cities");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Categories",
                table: "Categories");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Addresses",
                table: "Addresses");

            migrationBuilder.DropColumn(
                name: "Property_ID",
                table: "Properties");

            migrationBuilder.DropColumn(
                name: "Property_ID",
                table: "Listings");

            migrationBuilder.RenameTable(
                name: "SubCategories",
                newName: "SubCategory");

            migrationBuilder.RenameTable(
                name: "Properties",
                newName: "Property");

            migrationBuilder.RenameTable(
                name: "Photos",
                newName: "Photo");

            migrationBuilder.RenameTable(
                name: "Offers",
                newName: "Offer");

            migrationBuilder.RenameTable(
                name: "Listings",
                newName: "Listing");

            migrationBuilder.RenameTable(
                name: "Directons",
                newName: "Directon");

            migrationBuilder.RenameTable(
                name: "Currencies",
                newName: "Currency");

            migrationBuilder.RenameTable(
                name: "Countries",
                newName: "Country");

            migrationBuilder.RenameTable(
                name: "Cities",
                newName: "City");

            migrationBuilder.RenameTable(
                name: "Categories",
                newName: "Category");

            migrationBuilder.RenameTable(
                name: "Addresses",
                newName: "Address");

            migrationBuilder.RenameColumn(
                name: "TagName",
                table: "Tags",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "TagDescription",
                table: "Tags",
                newName: "Description");

            migrationBuilder.RenameColumn(
                name: "FeaturesProperty_ID",
                table: "Tags",
                newName: "FeaturesPropertyID");

            migrationBuilder.RenameColumn(
                name: "Tag_ID",
                table: "Tags",
                newName: "ID");

            migrationBuilder.RenameIndex(
                name: "IX_Tags_FeaturesProperty_ID",
                table: "Tags",
                newName: "IX_Tags_FeaturesPropertyID");

            migrationBuilder.RenameColumn(
                name: "Directon_ID",
                table: "Features",
                newName: "DirectonID");

            migrationBuilder.RenameColumn(
                name: "Property_ID",
                table: "Features",
                newName: "PropertyID");

            migrationBuilder.RenameIndex(
                name: "IX_Features_Directon_ID",
                table: "Features",
                newName: "IX_Features_DirectonID");

            migrationBuilder.RenameColumn(
                name: "SubCategoryName",
                table: "SubCategory",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "SubCategoryDescription",
                table: "SubCategory",
                newName: "Description");

            migrationBuilder.RenameColumn(
                name: "Category_ID",
                table: "SubCategory",
                newName: "CategoryID");

            migrationBuilder.RenameColumn(
                name: "SubCategory_ID",
                table: "SubCategory",
                newName: "ID");

            migrationBuilder.RenameColumn(
                name: "SubCategory_ID",
                table: "Property",
                newName: "SubCategoryID");

            migrationBuilder.RenameColumn(
                name: "Offer_ID",
                table: "Property",
                newName: "OfferID");

            migrationBuilder.RenameColumn(
                name: "Lister_ID",
                table: "Property",
                newName: "ListingID");

            migrationBuilder.RenameColumn(
                name: "Address_ID",
                table: "Property",
                newName: "AddressID");

            migrationBuilder.RenameIndex(
                name: "IX_Properties_SubCategory_ID",
                table: "Property",
                newName: "IX_Property_SubCategoryID");

            migrationBuilder.RenameIndex(
                name: "IX_Properties_Offer_ID",
                table: "Property",
                newName: "IX_Property_OfferID");

            migrationBuilder.RenameColumn(
                name: "Property_ID",
                table: "Photo",
                newName: "PropertyID");

            migrationBuilder.RenameColumn(
                name: "Photo_ID",
                table: "Photo",
                newName: "ID");

            migrationBuilder.RenameIndex(
                name: "IX_Photos_Property_ID",
                table: "Photo",
                newName: "IX_Photo_PropertyID");

            migrationBuilder.RenameColumn(
                name: "Currency_ID",
                table: "Offer",
                newName: "CurrencyID");

            migrationBuilder.RenameColumn(
                name: "Offer_ID",
                table: "Offer",
                newName: "ID");

            migrationBuilder.RenameIndex(
                name: "IX_Offers_Currency_ID",
                table: "Offer",
                newName: "IX_Offer_CurrencyID");

            migrationBuilder.RenameColumn(
                name: "User_ID",
                table: "Listing",
                newName: "UserID");

            migrationBuilder.RenameColumn(
                name: "Listing_ID",
                table: "Listing",
                newName: "ID");

            migrationBuilder.RenameColumn(
                name: "Directon_ID",
                table: "Directon",
                newName: "ID");

            migrationBuilder.RenameColumn(
                name: "CurrencySign",
                table: "Currency",
                newName: "Sign");

            migrationBuilder.RenameColumn(
                name: "CurrencyName",
                table: "Currency",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "Currency_ID",
                table: "Currency",
                newName: "ID");

            migrationBuilder.RenameColumn(
                name: "CountryNativeName",
                table: "Country",
                newName: "NativeName");

            migrationBuilder.RenameColumn(
                name: "CountryName",
                table: "Country",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "CountryCode",
                table: "Country",
                newName: "Code");

            migrationBuilder.RenameColumn(
                name: "Country_ID",
                table: "Country",
                newName: "ID");

            migrationBuilder.RenameColumn(
                name: "Country_ID",
                table: "City",
                newName: "CountryID");

            migrationBuilder.RenameColumn(
                name: "City_ID",
                table: "City",
                newName: "ID");

            migrationBuilder.RenameIndex(
                name: "IX_Cities_Country_ID",
                table: "City",
                newName: "IX_City_CountryID");

            migrationBuilder.RenameColumn(
                name: "CategoryName",
                table: "Category",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "CategoryDescription",
                table: "Category",
                newName: "Description");

            migrationBuilder.RenameColumn(
                name: "Category_ID",
                table: "Category",
                newName: "ID");

            migrationBuilder.RenameColumn(
                name: "Country_ID",
                table: "Address",
                newName: "CountryID");

            migrationBuilder.RenameColumn(
                name: "City_ID",
                table: "Address",
                newName: "CityID");

            migrationBuilder.RenameColumn(
                name: "Address_ID",
                table: "Address",
                newName: "ID");

            migrationBuilder.RenameIndex(
                name: "IX_Addresses_Country_ID",
                table: "Address",
                newName: "IX_Address_CountryID");

            migrationBuilder.RenameIndex(
                name: "IX_Addresses_City_ID",
                table: "Address",
                newName: "IX_Address_CityID");

            migrationBuilder.AddColumn<int>(
                name: "ID",
                table: "Property",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "LocalSign",
                table: "Currency",
                maxLength: 20,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_SubCategory",
                table: "SubCategory",
                column: "ID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Property",
                table: "Property",
                column: "ID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Photo",
                table: "Photo",
                column: "ID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Offer",
                table: "Offer",
                column: "ID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Listing",
                table: "Listing",
                column: "ID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Directon",
                table: "Directon",
                column: "ID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Currency",
                table: "Currency",
                column: "ID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Country",
                table: "Country",
                column: "ID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_City",
                table: "City",
                column: "ID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Category",
                table: "Category",
                column: "ID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Address",
                table: "Address",
                column: "ID");

            migrationBuilder.CreateIndex(
                name: "IX_SubCategory_CategoryID",
                table: "SubCategory",
                column: "CategoryID",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Property_ListingID",
                table: "Property",
                column: "ListingID",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Address_City_CityID",
                table: "Address",
                column: "CityID",
                principalTable: "City",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Address_Country_CountryID",
                table: "Address",
                column: "CountryID",
                principalTable: "Country",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_City_Country_CountryID",
                table: "City",
                column: "CountryID",
                principalTable: "Country",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Features_Directon_DirectonID",
                table: "Features",
                column: "DirectonID",
                principalTable: "Directon",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Features_Property_PropertyID",
                table: "Features",
                column: "PropertyID",
                principalTable: "Property",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Offer_Currency_CurrencyID",
                table: "Offer",
                column: "CurrencyID",
                principalTable: "Currency",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Photo_Property_PropertyID",
                table: "Photo",
                column: "PropertyID",
                principalTable: "Property",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Property_Address_ID",
                table: "Property",
                column: "ID",
                principalTable: "Address",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Property_Listing_ListingID",
                table: "Property",
                column: "ListingID",
                principalTable: "Listing",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Property_Offer_OfferID",
                table: "Property",
                column: "OfferID",
                principalTable: "Offer",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Property_SubCategory_SubCategoryID",
                table: "Property",
                column: "SubCategoryID",
                principalTable: "SubCategory",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SubCategory_Category_CategoryID",
                table: "SubCategory",
                column: "CategoryID",
                principalTable: "Category",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Tags_Features_FeaturesPropertyID",
                table: "Tags",
                column: "FeaturesPropertyID",
                principalTable: "Features",
                principalColumn: "PropertyID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Address_City_CityID",
                table: "Address");

            migrationBuilder.DropForeignKey(
                name: "FK_Address_Country_CountryID",
                table: "Address");

            migrationBuilder.DropForeignKey(
                name: "FK_City_Country_CountryID",
                table: "City");

            migrationBuilder.DropForeignKey(
                name: "FK_Features_Directon_DirectonID",
                table: "Features");

            migrationBuilder.DropForeignKey(
                name: "FK_Features_Property_PropertyID",
                table: "Features");

            migrationBuilder.DropForeignKey(
                name: "FK_Offer_Currency_CurrencyID",
                table: "Offer");

            migrationBuilder.DropForeignKey(
                name: "FK_Photo_Property_PropertyID",
                table: "Photo");

            migrationBuilder.DropForeignKey(
                name: "FK_Property_Address_ID",
                table: "Property");

            migrationBuilder.DropForeignKey(
                name: "FK_Property_Listing_ListingID",
                table: "Property");

            migrationBuilder.DropForeignKey(
                name: "FK_Property_Offer_OfferID",
                table: "Property");

            migrationBuilder.DropForeignKey(
                name: "FK_Property_SubCategory_SubCategoryID",
                table: "Property");

            migrationBuilder.DropForeignKey(
                name: "FK_SubCategory_Category_CategoryID",
                table: "SubCategory");

            migrationBuilder.DropForeignKey(
                name: "FK_Tags_Features_FeaturesPropertyID",
                table: "Tags");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SubCategory",
                table: "SubCategory");

            migrationBuilder.DropIndex(
                name: "IX_SubCategory_CategoryID",
                table: "SubCategory");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Property",
                table: "Property");

            migrationBuilder.DropIndex(
                name: "IX_Property_ListingID",
                table: "Property");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Photo",
                table: "Photo");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Offer",
                table: "Offer");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Listing",
                table: "Listing");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Directon",
                table: "Directon");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Currency",
                table: "Currency");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Country",
                table: "Country");

            migrationBuilder.DropPrimaryKey(
                name: "PK_City",
                table: "City");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Category",
                table: "Category");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Address",
                table: "Address");

            migrationBuilder.DropColumn(
                name: "ID",
                table: "Property");

            migrationBuilder.DropColumn(
                name: "LocalSign",
                table: "Currency");

            migrationBuilder.RenameTable(
                name: "SubCategory",
                newName: "SubCategories");

            migrationBuilder.RenameTable(
                name: "Property",
                newName: "Properties");

            migrationBuilder.RenameTable(
                name: "Photo",
                newName: "Photos");

            migrationBuilder.RenameTable(
                name: "Offer",
                newName: "Offers");

            migrationBuilder.RenameTable(
                name: "Listing",
                newName: "Listings");

            migrationBuilder.RenameTable(
                name: "Directon",
                newName: "Directons");

            migrationBuilder.RenameTable(
                name: "Currency",
                newName: "Currencies");

            migrationBuilder.RenameTable(
                name: "Country",
                newName: "Countries");

            migrationBuilder.RenameTable(
                name: "City",
                newName: "Cities");

            migrationBuilder.RenameTable(
                name: "Category",
                newName: "Categories");

            migrationBuilder.RenameTable(
                name: "Address",
                newName: "Addresses");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Tags",
                newName: "TagName");

            migrationBuilder.RenameColumn(
                name: "FeaturesPropertyID",
                table: "Tags",
                newName: "FeaturesProperty_ID");

            migrationBuilder.RenameColumn(
                name: "Description",
                table: "Tags",
                newName: "TagDescription");

            migrationBuilder.RenameColumn(
                name: "ID",
                table: "Tags",
                newName: "Tag_ID");

            migrationBuilder.RenameIndex(
                name: "IX_Tags_FeaturesPropertyID",
                table: "Tags",
                newName: "IX_Tags_FeaturesProperty_ID");

            migrationBuilder.RenameColumn(
                name: "DirectonID",
                table: "Features",
                newName: "Directon_ID");

            migrationBuilder.RenameColumn(
                name: "PropertyID",
                table: "Features",
                newName: "Property_ID");

            migrationBuilder.RenameIndex(
                name: "IX_Features_DirectonID",
                table: "Features",
                newName: "IX_Features_Directon_ID");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "SubCategories",
                newName: "SubCategoryName");

            migrationBuilder.RenameColumn(
                name: "Description",
                table: "SubCategories",
                newName: "SubCategoryDescription");

            migrationBuilder.RenameColumn(
                name: "CategoryID",
                table: "SubCategories",
                newName: "Category_ID");

            migrationBuilder.RenameColumn(
                name: "ID",
                table: "SubCategories",
                newName: "SubCategory_ID");

            migrationBuilder.RenameColumn(
                name: "SubCategoryID",
                table: "Properties",
                newName: "SubCategory_ID");

            migrationBuilder.RenameColumn(
                name: "OfferID",
                table: "Properties",
                newName: "Offer_ID");

            migrationBuilder.RenameColumn(
                name: "ListingID",
                table: "Properties",
                newName: "Lister_ID");

            migrationBuilder.RenameColumn(
                name: "AddressID",
                table: "Properties",
                newName: "Address_ID");

            migrationBuilder.RenameIndex(
                name: "IX_Property_SubCategoryID",
                table: "Properties",
                newName: "IX_Properties_SubCategory_ID");

            migrationBuilder.RenameIndex(
                name: "IX_Property_OfferID",
                table: "Properties",
                newName: "IX_Properties_Offer_ID");

            migrationBuilder.RenameColumn(
                name: "PropertyID",
                table: "Photos",
                newName: "Property_ID");

            migrationBuilder.RenameColumn(
                name: "ID",
                table: "Photos",
                newName: "Photo_ID");

            migrationBuilder.RenameIndex(
                name: "IX_Photo_PropertyID",
                table: "Photos",
                newName: "IX_Photos_Property_ID");

            migrationBuilder.RenameColumn(
                name: "CurrencyID",
                table: "Offers",
                newName: "Currency_ID");

            migrationBuilder.RenameColumn(
                name: "ID",
                table: "Offers",
                newName: "Offer_ID");

            migrationBuilder.RenameIndex(
                name: "IX_Offer_CurrencyID",
                table: "Offers",
                newName: "IX_Offers_Currency_ID");

            migrationBuilder.RenameColumn(
                name: "UserID",
                table: "Listings",
                newName: "User_ID");

            migrationBuilder.RenameColumn(
                name: "ID",
                table: "Listings",
                newName: "Listing_ID");

            migrationBuilder.RenameColumn(
                name: "ID",
                table: "Directons",
                newName: "Directon_ID");

            migrationBuilder.RenameColumn(
                name: "Sign",
                table: "Currencies",
                newName: "CurrencySign");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Currencies",
                newName: "CurrencyName");

            migrationBuilder.RenameColumn(
                name: "ID",
                table: "Currencies",
                newName: "Currency_ID");

            migrationBuilder.RenameColumn(
                name: "NativeName",
                table: "Countries",
                newName: "CountryNativeName");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Countries",
                newName: "CountryName");

            migrationBuilder.RenameColumn(
                name: "Code",
                table: "Countries",
                newName: "CountryCode");

            migrationBuilder.RenameColumn(
                name: "ID",
                table: "Countries",
                newName: "Country_ID");

            migrationBuilder.RenameColumn(
                name: "CountryID",
                table: "Cities",
                newName: "Country_ID");

            migrationBuilder.RenameColumn(
                name: "ID",
                table: "Cities",
                newName: "City_ID");

            migrationBuilder.RenameIndex(
                name: "IX_City_CountryID",
                table: "Cities",
                newName: "IX_Cities_Country_ID");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Categories",
                newName: "CategoryName");

            migrationBuilder.RenameColumn(
                name: "Description",
                table: "Categories",
                newName: "CategoryDescription");

            migrationBuilder.RenameColumn(
                name: "ID",
                table: "Categories",
                newName: "Category_ID");

            migrationBuilder.RenameColumn(
                name: "CountryID",
                table: "Addresses",
                newName: "Country_ID");

            migrationBuilder.RenameColumn(
                name: "CityID",
                table: "Addresses",
                newName: "City_ID");

            migrationBuilder.RenameColumn(
                name: "ID",
                table: "Addresses",
                newName: "Address_ID");

            migrationBuilder.RenameIndex(
                name: "IX_Address_CountryID",
                table: "Addresses",
                newName: "IX_Addresses_Country_ID");

            migrationBuilder.RenameIndex(
                name: "IX_Address_CityID",
                table: "Addresses",
                newName: "IX_Addresses_City_ID");

            migrationBuilder.AddColumn<int>(
                name: "Property_ID",
                table: "Properties",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            migrationBuilder.AddColumn<int>(
                name: "Property_ID",
                table: "Listings",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_SubCategories",
                table: "SubCategories",
                column: "SubCategory_ID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Properties",
                table: "Properties",
                column: "Property_ID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Photos",
                table: "Photos",
                column: "Photo_ID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Offers",
                table: "Offers",
                column: "Offer_ID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Listings",
                table: "Listings",
                column: "Listing_ID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Directons",
                table: "Directons",
                column: "Directon_ID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Currencies",
                table: "Currencies",
                column: "Currency_ID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Countries",
                table: "Countries",
                column: "Country_ID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Cities",
                table: "Cities",
                column: "City_ID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Categories",
                table: "Categories",
                column: "Category_ID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Addresses",
                table: "Addresses",
                column: "Address_ID");

            migrationBuilder.CreateIndex(
                name: "IX_SubCategories_Category_ID",
                table: "SubCategories",
                column: "Category_ID");

            migrationBuilder.CreateIndex(
                name: "IX_Properties_Address_ID",
                table: "Properties",
                column: "Address_ID",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Listings_Property_ID",
                table: "Listings",
                column: "Property_ID");

            migrationBuilder.AddForeignKey(
                name: "FK_Addresses_Cities_City_ID",
                table: "Addresses",
                column: "City_ID",
                principalTable: "Cities",
                principalColumn: "City_ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Addresses_Countries_Country_ID",
                table: "Addresses",
                column: "Country_ID",
                principalTable: "Countries",
                principalColumn: "Country_ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Cities_Countries_Country_ID",
                table: "Cities",
                column: "Country_ID",
                principalTable: "Countries",
                principalColumn: "Country_ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Features_Directons_Directon_ID",
                table: "Features",
                column: "Directon_ID",
                principalTable: "Directons",
                principalColumn: "Directon_ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Features_Properties_Property_ID",
                table: "Features",
                column: "Property_ID",
                principalTable: "Properties",
                principalColumn: "Property_ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Listings_Properties_Property_ID",
                table: "Listings",
                column: "Property_ID",
                principalTable: "Properties",
                principalColumn: "Property_ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Offers_Currencies_Currency_ID",
                table: "Offers",
                column: "Currency_ID",
                principalTable: "Currencies",
                principalColumn: "Currency_ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Photos_Properties_Property_ID",
                table: "Photos",
                column: "Property_ID",
                principalTable: "Properties",
                principalColumn: "Property_ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Properties_Addresses_Address_ID",
                table: "Properties",
                column: "Address_ID",
                principalTable: "Addresses",
                principalColumn: "Address_ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Properties_Offers_Offer_ID",
                table: "Properties",
                column: "Offer_ID",
                principalTable: "Offers",
                principalColumn: "Offer_ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Properties_SubCategories_SubCategory_ID",
                table: "Properties",
                column: "SubCategory_ID",
                principalTable: "SubCategories",
                principalColumn: "SubCategory_ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SubCategories_Categories_Category_ID",
                table: "SubCategories",
                column: "Category_ID",
                principalTable: "Categories",
                principalColumn: "Category_ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Tags_Features_FeaturesProperty_ID",
                table: "Tags",
                column: "FeaturesProperty_ID",
                principalTable: "Features",
                principalColumn: "Property_ID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
