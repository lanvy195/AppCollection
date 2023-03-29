# AppCollection
Collect Employee Ideas
#hướng dẫn connect database 
Vào View > SQL server object exlorer >SQL Server   // để kiểm tra kết nối database
Vào appsetting.json tại thanh Solution Explorer sẽ thấy dòng dưới 6-9
 "ConnectionStrings": {
    "DefaultConnection": "Server=(localdb)\\.;Database=AppCollection;Trusted_Connection=True;", 
    "ApplicationDbContextConnection": "Server=(localdb)\\mssqllocaldb;Database=AppCollection;Trusted_Connection=True;MultipleActiveResultSets=true"
  },
   //ở đây Server sẽ là tên máy chủ Sql , Database là tên file database. Các bạn trong project này có thể để mặc định "(localdb)\\." không cần thay đổi.
   Trên thanh công cụ chọn Tools > NuGet packpage Manager > NuGet Package Console 
   Sau đó gõ "update-database" visual sẽ tự động backup data lên SQL. tiếp đến refresh lại SQL Server tại SQL server object exlorer sẽ thấy database AppCollection đã được tạo.
Check!
