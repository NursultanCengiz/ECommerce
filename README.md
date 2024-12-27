# ECommerce
Müşteri, ürün ve sipariş oluşturma akışları ile bu oluşturulan bilgiler kullanarak çeşitli verilerin gösterildiği kısa bir e-ticaret projesidir.

# Proje yapılırken kullanılan teknolojiler:
1- Asp.Net Web Api(v8)

2- Sql Server

3- EntityFrameworkCore 

# Proje yapılırken uygulanan adımlar:

1)Sql üzerinden ECommerceDatabase oluşturuldu.

2)Sql içinde alttaki kodlarla Product ve Order tabloları oluşturuldu.

CREATE TABLE [dbo].[Product]
(
	[Id] INT NOT NULL PRIMARY KEY,
	[Name] VARCHAR(50) NOT NULL,
	[Price] DECIMAL(18,2) NOT NULL,
	[Stock] INT NOT NULL
)

CREATE TABLE [dbo].[Order]
(
	[Id] INT NOT NULL PRIMARY KEY, 
    [ProductId] INT NULL, 
    [Quantity] INT NOT NULL, 
    [OrderDate] DATETIME NOT NULL, 
    CONSTRAINT [FK_Order_Product_ProductId] FOREIGN KEY ([ProductId]) REFERENCES [Product]([Id])
)

3)ECommerce .Net Web Api projesi Visual Studio aracılığıyla oluşturuldu.

4)ECommerce projesine EntityFrameworkCore.Design, Sqlserver ve Tools paketleri Nuget üzerinden indirildi.

5)Db First yöntemi için Package Manager Console açıldı alttaki kod çalıştırılarak context ve modeller proje içerisindeki Data klasörüne oluşturuldu.

Scaffold-DbContext 'Data Source=(localdb)\MSSQLLocalDB;Database=ECommerceDatabase;Trusted_Connection=true;' Microsoft.EntityFrameworkCore.SqlServer -OutputDir Data

6)Code First yöntemi için Customer model oluşturuldu ECommerceDatabaseContext içerisine tanımı DbSet olarak verildi ve 
	Package manager console açıldı ardından alttaki kod blokları sırasıyla çalıştırılarak migration oluşturuldu ve database update yapıldı.
	
 Add-Migration InitialCreate
 Update-Database

7)Proje kapsamında istenilen apiler için controller'lar oluşturuldu. İçerisine servislerden bağımsız apiler dolduruldu.

8)Servis katmanındaki işlemleri yapmak üzere customer, product ve order modelleri için IRepository ve Repository'ler oluşturuldu sonrasında apilerde kullanılmak üzere metodların içleri dolduruldu.

9)Context ve Repository'lerin proje içerisinde kullanılması için Dependency Injection yardımıyla Program.cs içerisinde tanımlar yapıldı.

10)Oluşturulan repositoryler controller içerisinde tanımlandı ve apilere bağlandı.

11)Proje çalıştırılarak apiler test edildi.

