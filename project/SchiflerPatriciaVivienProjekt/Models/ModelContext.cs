using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace SchiflerPatriciaVivienProjekt.Models
{
    public partial class ModelContext : DbContext
    {
        public ModelContext()
        {
        }

        public ModelContext(DbContextOptions<ModelContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Bill> Bills { get; set; }
        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<Customer> Customers { get; set; }
        public virtual DbSet<Department> Departments { get; set; }
        public virtual DbSet<Discount> Discounts { get; set; }
        public virtual DbSet<Employee> Employees { get; set; }
        public virtual DbSet<Location> Locations { get; set; }
        public virtual DbSet<OrderProduct> OrderProducts { get; set; }
        public virtual DbSet<PaymentType> PaymentTypes { get; set; }
        public virtual DbSet<Position> Positions { get; set; }
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<Shop> Shops { get; set; }
        public virtual DbSet<Supplier> Suppliers { get; set; }
        public virtual DbSet<SupplyPlace> SupplyPlaces { get; set; }
        public virtual DbSet<Supplying> Supplyings { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseOracle("User Id=C##Tavk7; Password=DEF567mop; Data Source=217.73.170.84:44678/orcl;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("C##TAVK7");

            modelBuilder.Entity<Bill>(entity =>
            {
                entity.ToTable("BILLS");

                entity.HasIndex(e => new { e.BillDatetime, e.LocationId, e.PaymentTypeId, e.CustomerId, e.EmployeeId, e.ShopId }, "UNIQUE_BILL")
                    .IsUnique();

                entity.Property(e => e.BillId)
                    .HasColumnType("NUMBER")
                    .HasColumnName("BILL_ID")
                    .HasDefaultValueSql("\"C##TAVK7\".\"IDS\".\"NEXTVAL\"");

                entity.Property(e => e.BillDatetime)
                    .IsRequired()
                    .HasMaxLength(14)
                    .IsUnicode(false)
                    .HasColumnName("BILL_DATETIME");

                entity.Property(e => e.CustomerId)
                    .HasColumnType("NUMBER")
                    .HasColumnName("CUSTOMER_ID");

                entity.Property(e => e.EmployeeId)
                    .HasColumnType("NUMBER")
                    .HasColumnName("EMPLOYEE_ID");

                entity.Property(e => e.LocationId)
                    .HasColumnType("NUMBER")
                    .HasColumnName("LOCATION_ID");

                entity.Property(e => e.PaymentTypeId)
                    .HasColumnType("NUMBER")
                    .HasColumnName("PAYMENT_TYPE_ID");

                entity.Property(e => e.ShopId)
                    .HasColumnType("NUMBER")
                    .HasColumnName("SHOP_ID");

                entity.Property(e => e.Total)
                    .HasColumnType("NUMBER")
                    .HasColumnName("TOTAL");

                entity.HasOne(d => d.Customer)
                    .WithMany(p => p.Bills)
                    .HasForeignKey(d => d.CustomerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_BILL_CUSTOMER_ID");

                entity.HasOne(d => d.Employee)
                    .WithMany(p => p.Bills)
                    .HasForeignKey(d => d.EmployeeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_BILL_EMP_ID");

                entity.HasOne(d => d.Location)
                    .WithMany(p => p.Bills)
                    .HasForeignKey(d => d.LocationId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_BILL_LOCATION_ID");

                entity.HasOne(d => d.PaymentType)
                    .WithMany(p => p.Bills)
                    .HasForeignKey(d => d.PaymentTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_BILL_PAYMENT_TYPE_ID");

                entity.HasOne(d => d.Shop)
                    .WithMany(p => p.Bills)
                    .HasForeignKey(d => d.ShopId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_BILL_SHOP_ID");
            });

            modelBuilder.Entity<Category>(entity =>
            {
                entity.ToTable("CATEGORIES");

                entity.Property(e => e.CategoryId)
                    .HasColumnType("NUMBER")
                    .HasColumnName("CATEGORY_ID")
                    .HasDefaultValueSql("\"C##TAVK7\".\"IDS\".\"NEXTVAL\"");

                entity.Property(e => e.CategoryName)
                    .IsRequired()
                    .HasMaxLength(25)
                    .IsUnicode(false)
                    .HasColumnName("CATEGORY_NAME");
            });

            modelBuilder.Entity<Customer>(entity =>
            {
                entity.ToTable("CUSTOMERS");

                entity.HasIndex(e => e.CustomerPhoneNum, "SYS_C00112191")
                    .IsUnique();

                entity.HasIndex(e => e.CustomerEmail, "SYS_C00112192")
                    .IsUnique();

                entity.HasIndex(e => new { e.CustomerName, e.CustomerPhoneNum, e.CustomerEmail, e.LocationId, e.CustomerAdress }, "UNIQUE_CUSTOMER")
                    .IsUnique();

                entity.Property(e => e.CustomerId)
                    .HasColumnType("NUMBER")
                    .HasColumnName("CUSTOMER_ID")
                    .HasDefaultValueSql("\"C##TAVK7\".\"IDS\".\"NEXTVAL\"");

                entity.Property(e => e.CustomerAdress)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("CUSTOMER_ADRESS");

                entity.Property(e => e.CustomerEmail)
                    .IsRequired()
                    .HasMaxLength(35)
                    .IsUnicode(false)
                    .HasColumnName("CUSTOMER_EMAIL");

                entity.Property(e => e.CustomerName)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("CUSTOMER_NAME");

                entity.Property(e => e.CustomerPhoneNum)
                    .IsRequired()
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasColumnName("CUSTOMER_PHONE_NUM");

                entity.Property(e => e.LocationId)
                    .HasColumnType("NUMBER")
                    .HasColumnName("LOCATION_ID");

                entity.HasOne(d => d.Location)
                    .WithMany(p => p.Customers)
                    .HasForeignKey(d => d.LocationId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_CUSTOMER_LOC_ID");
            });

            modelBuilder.Entity<Department>(entity =>
            {
                entity.ToTable("DEPARTMENTS");

                entity.HasIndex(e => e.DepartmentName, "SYS_C00112103")
                    .IsUnique();

                entity.Property(e => e.DepartmentId)
                    .HasColumnType("NUMBER")
                    .HasColumnName("DEPARTMENT_ID")
                    .HasDefaultValueSql("\"C##TAVK7\".\"IDS\".\"NEXTVAL\"");

                entity.Property(e => e.DepartmentName)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("DEPARTMENT_NAME");
            });

            modelBuilder.Entity<Discount>(entity =>
            {
                entity.ToTable("DISCOUNT");

                entity.HasIndex(e => new { e.StartDate, e.EndDate, e.Percentage }, "UNIQUE_DISCOUNT_DATE")
                    .IsUnique();

                entity.Property(e => e.DiscountId)
                    .HasColumnType("NUMBER")
                    .HasColumnName("DISCOUNT_ID")
                    .HasDefaultValueSql("\"C##TAVK7\".\"IDS\".\"NEXTVAL\"");

                entity.Property(e => e.EndDate)
                    .HasColumnType("DATE")
                    .HasColumnName("END_DATE");

                entity.Property(e => e.Percentage)
                    .HasColumnType("NUMBER")
                    .HasColumnName("PERCENTAGE");

                entity.Property(e => e.StartDate)
                    .HasColumnType("DATE")
                    .HasColumnName("START_DATE");
            });

            modelBuilder.Entity<Employee>(entity =>
            {
                entity.HasKey(e => e.EmpId)
                    .HasName("SYS_C00112129");

                entity.ToTable("EMPLOYEES");

                entity.HasIndex(e => e.EmpPhoneNum, "SYS_C00112130")
                    .IsUnique();

                entity.HasIndex(e => e.EmpEmail, "SYS_C00112131")
                    .IsUnique();

                entity.HasIndex(e => new { e.EmpName, e.EmpPhoneNum, e.EmpEmail, e.EmpAddress }, "UNIQUE_EMPS")
                    .IsUnique();

                entity.Property(e => e.EmpId)
                    .HasColumnType("NUMBER")
                    .HasColumnName("EMP_ID")
                    .HasDefaultValueSql("\"C##TAVK7\".\"IDS\".\"NEXTVAL\"");

                entity.Property(e => e.DepartmentId)
                    .HasColumnType("NUMBER")
                    .HasColumnName("DEPARTMENT_ID");

                entity.Property(e => e.EmpAddress)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("EMP_ADDRESS");

                entity.Property(e => e.EmpEmail)
                    .IsRequired()
                    .HasMaxLength(35)
                    .IsUnicode(false)
                    .HasColumnName("EMP_EMAIL");

                entity.Property(e => e.EmpName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("EMP_NAME");

                entity.Property(e => e.EmpPhoneNum)
                    .IsRequired()
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasColumnName("EMP_PHONE_NUM");

                entity.Property(e => e.EmpPosition)
                    .IsRequired()
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasColumnName("EMP_POSITION");

                entity.Property(e => e.EmpSalary)
                    .HasColumnType("NUMBER")
                    .HasColumnName("EMP_SALARY");

                entity.Property(e => e.LocationId)
                    .HasColumnType("NUMBER")
                    .HasColumnName("LOCATION_ID");

                entity.Property(e => e.ShopId)
                    .HasColumnType("NUMBER")
                    .HasColumnName("SHOP_ID");

                entity.HasOne(d => d.Department)
                    .WithMany(p => p.Employees)
                    .HasForeignKey(d => d.DepartmentId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_EMP_DEPARTMENT_ID");

                entity.HasOne(d => d.Location)
                    .WithMany(p => p.Employees)
                    .HasForeignKey(d => d.LocationId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_EMP_LOCATION_ID");

                entity.HasOne(d => d.Shop)
                    .WithMany(p => p.Employees)
                    .HasForeignKey(d => d.ShopId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_EMP_SHOP_ID");
            });

            modelBuilder.Entity<Location>(entity =>
            {
                entity.ToTable("LOCATIONS");

                entity.HasIndex(e => e.LocationName, "SYS_C00111997")
                    .IsUnique();

                entity.Property(e => e.LocationId)
                    .HasColumnType("NUMBER")
                    .HasColumnName("LOCATION_ID")
                    .HasDefaultValueSql("\"C##TAVK7\".\"IDS\".\"NEXTVAL\"");

                entity.Property(e => e.LocationCountry)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("LOCATION_COUNTRY");

                entity.Property(e => e.LocationCounty)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("LOCATION_COUNTY");

                entity.Property(e => e.LocationName)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("LOCATION_NAME");

                entity.Property(e => e.ShortLocationCountry)
                    .IsRequired()
                    .HasMaxLength(5)
                    .IsUnicode(false)
                    .HasColumnName("SHORT_LOCATION_COUNTRY");

                entity.Property(e => e.ShortLocationCounty)
                    .IsRequired()
                    .HasMaxLength(5)
                    .IsUnicode(false)
                    .HasColumnName("SHORT_LOCATION_COUNTY");
            });

            modelBuilder.Entity<OrderProduct>(entity =>
            {
                entity.HasKey(e => e.OrderProductsId)
                    .HasName("SYS_C00112202");

                entity.ToTable("ORDER_PRODUCTS");

                entity.Property(e => e.OrderProductsId)
                    .HasColumnType("NUMBER")
                    .HasColumnName("ORDER_PRODUCTS_ID")
                    .HasDefaultValueSql("\"C##TAVK7\".\"IDS\".\"NEXTVAL\"");

                entity.Property(e => e.BillId)
                    .HasColumnType("NUMBER")
                    .HasColumnName("BILL_ID");

                entity.Property(e => e.ProductId)
                    .HasColumnType("NUMBER")
                    .HasColumnName("PRODUCT_ID");

                entity.Property(e => e.Quantity)
                    .HasColumnType("NUMBER")
                    .HasColumnName("QUANTITY");
            });

            modelBuilder.Entity<PaymentType>(entity =>
            {
                entity.ToTable("PAYMENT_TYPE");

                entity.Property(e => e.PaymentTypeId)
                    .HasColumnType("NUMBER")
                    .HasColumnName("PAYMENT_TYPE_ID")
                    .HasDefaultValueSql("\"C##TAVK7\".\"IDS\".\"NEXTVAL\"");

                entity.Property(e => e.PaymentTypeName)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("PAYMENT_TYPE_NAME");
            });

            modelBuilder.Entity<Position>(entity =>
            {
                entity.ToTable("POSITIONS");

                entity.HasIndex(e => new { e.PositionName, e.DepartmentId }, "UNIQUE_POS")
                    .IsUnique();

                entity.Property(e => e.PositionId)
                    .HasColumnType("NUMBER")
                    .HasColumnName("POSITION_ID")
                    .HasDefaultValueSql("\"C##TAVK7\".\"IDS\".\"NEXTVAL\"");

                entity.Property(e => e.DepartmentId)
                    .HasColumnType("NUMBER")
                    .HasColumnName("DEPARTMENT_ID");

                entity.Property(e => e.PositionName)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("POSITION_NAME");

                entity.HasOne(d => d.Department)
                    .WithMany(p => p.Positions)
                    .HasForeignKey(d => d.DepartmentId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_POSITION_DEPARTMENT_ID");
            });

            modelBuilder.Entity<Product>(entity =>
            {
                entity.ToTable("PRODUCTS");

                entity.HasIndex(e => new { e.ProductName, e.CategoryId }, "UNIQUE_PRODUCT")
                    .IsUnique();

                entity.HasIndex(e => new { e.ProductName, e.CategoryId, e.DiscountId }, "UNIQUE_PRODUCT_DISCOUNT")
                    .IsUnique();

                entity.Property(e => e.ProductId)
                    .HasColumnType("NUMBER")
                    .HasColumnName("PRODUCT_ID")
                    .HasDefaultValueSql("\"C##TAVK7\".\"IDS\".\"NEXTVAL\"");

                entity.Property(e => e.CategoryId)
                    .HasColumnType("NUMBER")
                    .HasColumnName("CATEGORY_ID");

                entity.Property(e => e.DiscountId)
                    .HasColumnType("NUMBER")
                    .HasColumnName("DISCOUNT_ID");

                entity.Property(e => e.DiscountPricePerPiece)
                    .HasColumnType("NUMBER")
                    .HasColumnName("DISCOUNT_PRICE_PER_PIECE");

                entity.Property(e => e.NormalPricePerPiece)
                    .HasColumnType("NUMBER")
                    .HasColumnName("NORMAL_PRICE_PER_PIECE");

                entity.Property(e => e.ProductName)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("PRODUCT_NAME");

                entity.Property(e => e.Quantity)
                    .HasColumnType("NUMBER")
                    .HasColumnName("QUANTITY");

                entity.HasOne(d => d.Category)
                    .WithMany(p => p.Products)
                    .HasForeignKey(d => d.CategoryId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PROD_CATEGORY_ID");

                entity.HasOne(d => d.Discount)
                    .WithMany(p => p.Products)
                    .HasForeignKey(d => d.DiscountId)
                    .HasConstraintName("FK_PROD_DISCOUNT_ID");
            });

            modelBuilder.Entity<Shop>(entity =>
            {
                entity.ToTable("SHOPS");

                entity.HasIndex(e => new { e.ShopName, e.ShopAddress, e.LocationId, e.DepartmentId }, "UNIQUE_LOC_DEP")
                    .IsUnique();

                entity.Property(e => e.ShopId)
                    .HasColumnType("NUMBER")
                    .HasColumnName("SHOP_ID")
                    .HasDefaultValueSql("\"C##TAVK7\".\"IDS\".\"NEXTVAL\"");

                entity.Property(e => e.DepartmentId)
                    .HasColumnType("NUMBER")
                    .HasColumnName("DEPARTMENT_ID");

                entity.Property(e => e.LocationId)
                    .HasColumnType("NUMBER")
                    .HasColumnName("LOCATION_ID");

                entity.Property(e => e.ShopAddress)
                    .IsRequired()
                    .HasMaxLength(40)
                    .IsUnicode(false)
                    .HasColumnName("SHOP_ADDRESS");

                entity.Property(e => e.ShopName)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("SHOP_NAME");

                entity.HasOne(d => d.Department)
                    .WithMany(p => p.Shops)
                    .HasForeignKey(d => d.DepartmentId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_SHOPS_DEPARTMENT_ID");

                entity.HasOne(d => d.Location)
                    .WithMany(p => p.Shops)
                    .HasForeignKey(d => d.LocationId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_SHOP_LOCATION_ID");
            });

            modelBuilder.Entity<Supplier>(entity =>
            {
                entity.ToTable("SUPPLIERS");

                entity.HasIndex(e => new { e.SupplierPhoneNumber, e.SupplierEmail }, "UNIQUE_SUPPLIER")
                    .IsUnique();

                entity.Property(e => e.SupplierId)
                    .HasColumnType("NUMBER")
                    .HasColumnName("SUPPLIER_ID")
                    .HasDefaultValueSql("\"C##TAVK7\".\"IDS\".\"NEXTVAL\"");

                entity.Property(e => e.LocationId)
                    .HasColumnType("NUMBER")
                    .HasColumnName("LOCATION_ID");

                entity.Property(e => e.SupplierAddress)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("SUPPLIER_ADDRESS");

                entity.Property(e => e.SupplierEmail)
                    .IsRequired()
                    .HasMaxLength(35)
                    .IsUnicode(false)
                    .HasColumnName("SUPPLIER_EMAIL");

                entity.Property(e => e.SupplierName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("SUPPLIER_NAME");

                entity.Property(e => e.SupplierPhoneNumber)
                    .IsRequired()
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasColumnName("SUPPLIER_PHONE_NUMBER");

                entity.HasOne(d => d.Location)
                    .WithMany(p => p.Suppliers)
                    .HasForeignKey(d => d.LocationId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_SUPPLIER_LOCATIONS");
            });

            modelBuilder.Entity<SupplyPlace>(entity =>
            {
                entity.ToTable("SUPPLY_PLACES");

                entity.HasIndex(e => new { e.SupplyPlaceName, e.SupplyPlaceAddress }, "UNIQUE_SUPPLY_PLACE_NAME_ADDRESS")
                    .IsUnique();

                entity.Property(e => e.SupplyPlaceId)
                    .HasColumnType("NUMBER")
                    .HasColumnName("SUPPLY_PLACE_ID")
                    .HasDefaultValueSql("\"C##TAVK7\".\"IDS\".\"NEXTVAL\"");

                entity.Property(e => e.LocationId)
                    .HasColumnType("NUMBER")
                    .HasColumnName("LOCATION_ID");

                entity.Property(e => e.SupplyPlaceAddress)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("SUPPLY_PLACE_ADDRESS");

                entity.Property(e => e.SupplyPlaceName)
                    .IsRequired()
                    .HasMaxLength(65)
                    .IsUnicode(false)
                    .HasColumnName("SUPPLY_PLACE_NAME");

                entity.HasOne(d => d.Location)
                    .WithMany(p => p.SupplyPlaces)
                    .HasForeignKey(d => d.LocationId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_LOCATIONS");
            });

            modelBuilder.Entity<Supplying>(entity =>
            {
                entity.ToTable("SUPPLYING");

                entity.Property(e => e.SupplyingId)
                    .HasColumnType("NUMBER")
                    .HasColumnName("SUPPLYING_ID")
                    .HasDefaultValueSql("\"C##TAVK7\".\"IDS\".\"NEXTVAL\"+10");

                entity.Property(e => e.SupplierId)
                    .HasColumnType("NUMBER")
                    .HasColumnName("SUPPLIER_ID");

                entity.Property(e => e.SupplyingDate)
                    .HasColumnType("DATE")
                    .HasColumnName("SUPPLYING_DATE");

                entity.Property(e => e.SupplyingPlaceId)
                    .HasColumnType("NUMBER")
                    .HasColumnName("SUPPLYING_PLACE_ID");

                entity.Property(e => e.SupplyingTime)
                    .IsRequired()
                    .HasMaxLength(5)
                    .IsUnicode(false)
                    .HasColumnName("SUPPLYING_TIME");

                entity.HasOne(d => d.Supplier)
                    .WithMany(p => p.Supplyings)
                    .HasForeignKey(d => d.SupplierId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_SUPPLIER_ID");

                entity.HasOne(d => d.SupplyingPlace)
                    .WithMany(p => p.Supplyings)
                    .HasForeignKey(d => d.SupplyingPlaceId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_SUPPLY_PLACE_ID");
            });

            modelBuilder.HasSequence("BILL_IDS");

            modelBuilder.HasSequence("IDS");

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
