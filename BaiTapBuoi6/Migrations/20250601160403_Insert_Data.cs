using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BaiTapBuoi6.Migrations
{
    /// <inheritdoc />
    public partial class Insert_Data : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            // Insert Categories
            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                { 1, "Điện thoại" },
                { 2, "Laptop" },
                { 3, "Máy tính bảng" },
                { 4, "Đồng hồ thông minh" },
                { 5, "Phụ kiện" }
            });

            // Insert Products
            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Name", "Price", "Description", "ImageUrl", "CategoryId" },
                values: new object[,]
                {
            {
                1,
                "iPhone 15 Pro Max",
                34990000m,
                "iPhone 15 Pro Max. Titan chuẩn hàng không vũ trụ. Chip A17 Pro mạnh mẽ. Camera chuyên nghiệp 48MP.",
                "/images/products/iphone-15-pro-max.jpg",
                1
            },
            {
                2,
                "MacBook Air M2",
                32990000m,
                "Siêu mỏng nhẹ. Hiệu năng vượt trội với chip M2. Pin đến 18 giờ.",
                "/images/products/macbook-air-m2.jpg",
                2
            },
            {
                3,
                "iPad Pro M2",
                24990000m,
                "iPad Pro M2 mạnh như một chiếc laptop. Màn hình Liquid Retina XDR tuyệt đẹp.",
                "/images/products/ipad-pro-m2.jpg",
                3
            },
            {
                4,
                "Apple Watch Series 9",
                12990000m,
                "Apple Watch Series 9 với chip S9 mới. Theo dõi sức khỏe toàn diện.",
                "/images/products/apple-watch-s9.jpg",
                4
            },
            {
                5,
                "AirPods Pro 2",
                6990000m,
                "AirPods Pro với chip H2. Chống ồn chủ động thế hệ mới. Âm thanh không gian.",
                "/images/products/airpods-pro-2.jpg",
                5
            }
            });

        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.DeleteData(
            //table: "Products",
            //keyColumn: "Id",
            //keyValues: new object[] { 1, 2, 3, 4, 5 });

            //migrationBuilder.DeleteData(
            //    table: "Categories",
            //    keyColumn: "Id",
            //    keyValues: new object[] { 1, 2, 3, 4, 5 });
        }
    }
}
