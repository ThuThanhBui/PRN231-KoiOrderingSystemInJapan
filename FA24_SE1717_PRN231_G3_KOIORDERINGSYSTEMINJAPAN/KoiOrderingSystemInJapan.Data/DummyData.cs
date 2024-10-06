using Bogus;
using KoiOrderingSystemInJapan.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace KoiOrderingSystemInJapan.Data
{
    public static class DummyData
    {
        public static void SeedDatabase(DbContext context)
        {
            //GenerateCategories(context, 10);
            //GenerateSubjects(context, 20);
            //GenerateUsers(context, 40);
            //GenerateBlogs(context, 20);
            //GenerateProviders(context, 10);
            //GenerateAddresses(context, 10);
            //GenerateCourses(context, 50);
            //GenerateDayInWeeks(context, 20);
            //GenerateModules(context, 5);
            //GenerateStudents(context, 20);
            //GenerateFeedbacks(context, 20);
            //GeneratePackages(context, 20);
            //GeneratePackageXCourses(context, 50);
            //GenerateStudentXPackages(context, 150);
            //GenerateVouchers(context, 20);
            //GenerateOrders(context, 70);
        }
        public static void GenerateTravel(DbContext context, int count)
        {
            if (!context.Set<Travel>().Any())
            {
                var fakers = new Faker<Travel>()
                    .RuleFor(a => a.Id, f => Guid.NewGuid())
                    .RuleFor(a => a.Name, f => f.Name.FullName())
                    .RuleFor(a => a.Location, f => f.Address.StreetAddress())
                    .RuleFor(a => a.Price, f => f.Random.Decimal(100, 10000))
                    .RuleFor(s => s.CreatedBy, f => "tsql@gmail.com")
                    .RuleFor(s => s.CreatedDate, f => f.Date.Past(2))
                    .RuleFor(s => s.UpdatedBy, f => "tsql@gmail.com")
                    .RuleFor(s => s.UpdatedDate, f => f.Date.Recent())
                    .RuleFor(s => s.IsDeleted, f => false)
                    .RuleFor(a => a.Note, f => f.Lorem.Sentence());
                var list = fakers.Generate(count); // Tạo dữ liệu Assistant

                context.Set<Travel>().AddRange(list); // Thêm vào cơ sở dữ liệu
                context.SaveChanges(); // Lưu thay đổi
            }
        }

        //public static void GenerateFarm(DbContext context, int count)
        //{
        //    if (!context.Set<Farm>().Any())
        //    {
        //        var fakers = new Faker<Farm>()
        //            .RuleFor(a => a.Id, f => Guid.NewGuid())
        //            .RuleFor(a => a.Name, f => f.Name.FullName())
        //            .RuleFor(a => a.Owner, f => f.Company.CompanyName())
        //            .RuleFor(a => a.Location, f => f.Address.StreetAddress())
        //            .RuleFor(a => a.Price, f => f.Random.Decimal(100, 10000))
        //            .RuleFor(s => s.CreatedBy, f => "tsql@gmail.com")
        //            .RuleFor(s => s.CreatedDate, f => f.Date.Past(2))
        //            .RuleFor(s => s.UpdatedBy, f => "tsql@gmail.com")
        //            .RuleFor(s => s.UpdatedDate, f => f.Date.Recent())
        //            .RuleFor(s => s.IsDeleted, f => false)
        //            .RuleFor(a => a.Note, f => f.Lorem.Sentence());
        //        var list = fakers.Generate(count); // Tạo dữ liệu Assistant

        //        context.Set<>().AddRange(list); // Thêm vào cơ sở dữ liệu
        //        context.SaveChanges(); // Lưu thay đổi
        //    }
        //}

        //public static void Generate(DbContext context, int count)
        //{
        //    if (!context.Set<>().Any())
        //    {
        //        var fakers = new Faker<>()
        //            .RuleFor(a => a.Id, f => Guid.NewGuid())
        //            .RuleFor(a => a.Name, f => f.Name.FullName())
        //            .RuleFor(a => a.Location, f => f.Address.StreetAddress())
        //            .RuleFor(a => a.Price, f => f.Random.Decimal(100, 10000))
        //            .RuleFor(s => s.CreatedBy, f => "tsql@gmail.com")
        //            .RuleFor(s => s.CreatedDate, f => f.Date.Past(2))
        //            .RuleFor(s => s.UpdatedBy, f => "tsql@gmail.com")
        //            .RuleFor(s => s.UpdatedDate, f => f.Date.Recent())
        //            .RuleFor(s => s.IsDeleted, f => false)
        //            .RuleFor(a => a.Note, f => f.Lorem.Sentence());
        //        var list = fakers.Generate(count); // Tạo dữ liệu Assistant

        //        context.Set<>().AddRange(list); // Thêm vào cơ sở dữ liệu
        //        context.SaveChanges(); // Lưu thay đổi
        //    }
        //}

        //public static void Generate(DbContext context, int count)
        //{
        //    if (!context.Set<>().Any())
        //    {
        //        var fakers = new Faker<>()
        //            .RuleFor(a => a.Id, f => Guid.NewGuid())
        //            .RuleFor(a => a.Name, f => f.Name.FullName())
        //            .RuleFor(a => a.Location, f => f.Address.StreetAddress())
        //            .RuleFor(a => a.Price, f => f.Random.Decimal(100, 10000))
        //            .RuleFor(s => s.CreatedBy, f => "tsql@gmail.com")
        //            .RuleFor(s => s.CreatedDate, f => f.Date.Past(2))
        //            .RuleFor(s => s.UpdatedBy, f => "tsql@gmail.com")
        //            .RuleFor(s => s.UpdatedDate, f => f.Date.Recent())
        //            .RuleFor(s => s.IsDeleted, f => false)
        //            .RuleFor(a => a.Note, f => f.Lorem.Sentence());
        //        var list = fakers.Generate(count); // Tạo dữ liệu Assistant

        //        context.Set<>().AddRange(list); // Thêm vào cơ sở dữ liệu
        //        context.SaveChanges(); // Lưu thay đổi
        //    }
        //}

        //public static void Generate(DbContext context, int count)
        //{
        //    if (!context.Set<>().Any())
        //    {
        //        var fakers = new Faker<>()
        //            .RuleFor(a => a.Id, f => Guid.NewGuid())
        //            .RuleFor(a => a.Name, f => f.Name.FullName())
        //            .RuleFor(a => a.Location, f => f.Address.StreetAddress())
        //            .RuleFor(a => a.Price, f => f.Random.Decimal(100, 10000))
        //            .RuleFor(s => s.CreatedBy, f => "tsql@gmail.com")
        //            .RuleFor(s => s.CreatedDate, f => f.Date.Past(2))
        //            .RuleFor(s => s.UpdatedBy, f => "tsql@gmail.com")
        //            .RuleFor(s => s.UpdatedDate, f => f.Date.Recent())
        //            .RuleFor(s => s.IsDeleted, f => false)
        //            .RuleFor(a => a.Note, f => f.Lorem.Sentence());
        //        var list = fakers.Generate(count); // Tạo dữ liệu Assistant

        //        context.Set<>().AddRange(list); // Thêm vào cơ sở dữ liệu
        //        context.SaveChanges(); // Lưu thay đổi
        //    }
        //}

        //public static void Generate(DbContext context, int count)
        //{
        //    if (!context.Set<>().Any())
        //    {
        //        var fakers = new Faker<>()
        //            .RuleFor(a => a.Id, f => Guid.NewGuid())
        //            .RuleFor(a => a.Name, f => f.Name.FullName())
        //            .RuleFor(a => a.Location, f => f.Address.StreetAddress())
        //            .RuleFor(a => a.Price, f => f.Random.Decimal(100, 10000))
        //            .RuleFor(s => s.CreatedBy, f => "tsql@gmail.com")
        //            .RuleFor(s => s.CreatedDate, f => f.Date.Past(2))
        //            .RuleFor(s => s.UpdatedBy, f => "tsql@gmail.com")
        //            .RuleFor(s => s.UpdatedDate, f => f.Date.Recent())
        //            .RuleFor(s => s.IsDeleted, f => false)
        //            .RuleFor(a => a.Note, f => f.Lorem.Sentence());
        //        var list = fakers.Generate(count); // Tạo dữ liệu Assistant

        //        context.Set<>().AddRange(list); // Thêm vào cơ sở dữ liệu
        //        context.SaveChanges(); // Lưu thay đổi
        //    }
        //}

        //public static void Generate(DbContext context, int count)
        //{
        //    if (!context.Set<>().Any())
        //    {
        //        var fakers = new Faker<>()
        //            .RuleFor(a => a.Id, f => Guid.NewGuid())
        //            .RuleFor(a => a.Name, f => f.Name.FullName())
        //            .RuleFor(a => a.Location, f => f.Address.StreetAddress())
        //            .RuleFor(a => a.Price, f => f.Random.Decimal(100, 10000))
        //            .RuleFor(s => s.CreatedBy, f => "tsql@gmail.com")
        //            .RuleFor(s => s.CreatedDate, f => f.Date.Past(2))
        //            .RuleFor(s => s.UpdatedBy, f => "tsql@gmail.com")
        //            .RuleFor(s => s.UpdatedDate, f => f.Date.Recent())
        //            .RuleFor(s => s.IsDeleted, f => false)
        //            .RuleFor(a => a.Note, f => f.Lorem.Sentence());
        //        var list = fakers.Generate(count); // Tạo dữ liệu Assistant

        //        context.Set<>().AddRange(list); // Thêm vào cơ sở dữ liệu
        //        context.SaveChanges(); // Lưu thay đổi
        //    }
        //}

        //public static void Generate(DbContext context, int count)
        //{
        //    if (!context.Set<>().Any())
        //    {
        //        var fakers = new Faker<>()
        //            .RuleFor(a => a.Id, f => Guid.NewGuid())
        //            .RuleFor(a => a.Name, f => f.Name.FullName())
        //            .RuleFor(a => a.Location, f => f.Address.StreetAddress())
        //            .RuleFor(a => a.Price, f => f.Random.Decimal(100, 10000))
        //            .RuleFor(s => s.CreatedBy, f => "tsql@gmail.com")
        //            .RuleFor(s => s.CreatedDate, f => f.Date.Past(2))
        //            .RuleFor(s => s.UpdatedBy, f => "tsql@gmail.com")
        //            .RuleFor(s => s.UpdatedDate, f => f.Date.Recent())
        //            .RuleFor(s => s.IsDeleted, f => false)
        //            .RuleFor(a => a.Note, f => f.Lorem.Sentence());
        //        var list = fakers.Generate(count); // Tạo dữ liệu Assistant

        //        context.Set<>().AddRange(list); // Thêm vào cơ sở dữ liệu
        //        context.SaveChanges(); // Lưu thay đổi
        //    }
        //}

        //public static void Generate(DbContext context, int count)
        //{
        //    if (!context.Set<>().Any())
        //    {
        //        var fakers = new Faker<>()
        //            .RuleFor(a => a.Id, f => Guid.NewGuid())
        //            .RuleFor(a => a.Name, f => f.Name.FullName())
        //            .RuleFor(a => a.Location, f => f.Address.StreetAddress())
        //            .RuleFor(a => a.Price, f => f.Random.Decimal(100, 10000))
        //            .RuleFor(s => s.CreatedBy, f => "tsql@gmail.com")
        //            .RuleFor(s => s.CreatedDate, f => f.Date.Past(2))
        //            .RuleFor(s => s.UpdatedBy, f => "tsql@gmail.com")
        //            .RuleFor(s => s.UpdatedDate, f => f.Date.Recent())
        //            .RuleFor(s => s.IsDeleted, f => false)
        //            .RuleFor(a => a.Note, f => f.Lorem.Sentence());
        //        var list = fakers.Generate(count); // Tạo dữ liệu Assistant

        //        context.Set<>().AddRange(list); // Thêm vào cơ sở dữ liệu
        //        context.SaveChanges(); // Lưu thay đổi
        //    }
        //}

        //public static void Generate(DbContext context, int count)
        //{
        //    if (!context.Set<>().Any())
        //    {
        //        var fakers = new Faker<>()
        //            .RuleFor(a => a.Id, f => Guid.NewGuid())
        //            .RuleFor(a => a.Name, f => f.Name.FullName())
        //            .RuleFor(a => a.Location, f => f.Address.StreetAddress())
        //            .RuleFor(a => a.Price, f => f.Random.Decimal(100, 10000))
        //            .RuleFor(s => s.CreatedBy, f => "tsql@gmail.com")
        //            .RuleFor(s => s.CreatedDate, f => f.Date.Past(2))
        //            .RuleFor(s => s.UpdatedBy, f => "tsql@gmail.com")
        //            .RuleFor(s => s.UpdatedDate, f => f.Date.Recent())
        //            .RuleFor(s => s.IsDeleted, f => false)
        //            .RuleFor(a => a.Note, f => f.Lorem.Sentence());
        //        var list = fakers.Generate(count); // Tạo dữ liệu Assistant

        //        context.Set<>().AddRange(list); // Thêm vào cơ sở dữ liệu
        //        context.SaveChanges(); // Lưu thay đổi
        //    }
        //}

        //public static void Generate(DbContext context, int count)
        //{
        //    if (!context.Set<>().Any())
        //    {
        //        var fakers = new Faker<>()
        //            .RuleFor(a => a.Id, f => Guid.NewGuid())
        //            .RuleFor(a => a.Name, f => f.Name.FullName())
        //            .RuleFor(a => a.Location, f => f.Address.StreetAddress())
        //            .RuleFor(a => a.Price, f => f.Random.Decimal(100, 10000))
        //            .RuleFor(s => s.CreatedBy, f => "tsql@gmail.com")
        //            .RuleFor(s => s.CreatedDate, f => f.Date.Past(2))
        //            .RuleFor(s => s.UpdatedBy, f => "tsql@gmail.com")
        //            .RuleFor(s => s.UpdatedDate, f => f.Date.Recent())
        //            .RuleFor(s => s.IsDeleted, f => false)
        //            .RuleFor(a => a.Note, f => f.Lorem.Sentence());
        //        var list = fakers.Generate(count); // Tạo dữ liệu Assistant

        //        context.Set<>().AddRange(list); // Thêm vào cơ sở dữ liệu
        //        context.SaveChanges(); // Lưu thay đổi
        //    }
        //}

        //public static void Generate(DbContext context, int count)
        //{
        //    if (!context.Set<>().Any())
        //    {
        //        var fakers = new Faker<>()
        //            .RuleFor(a => a.Id, f => Guid.NewGuid())
        //            .RuleFor(a => a.Name, f => f.Name.FullName())
        //            .RuleFor(a => a.Location, f => f.Address.StreetAddress())
        //            .RuleFor(a => a.Price, f => f.Random.Decimal(100, 10000))
        //            .RuleFor(s => s.CreatedBy, f => "tsql@gmail.com")
        //            .RuleFor(s => s.CreatedDate, f => f.Date.Past(2))
        //            .RuleFor(s => s.UpdatedBy, f => "tsql@gmail.com")
        //            .RuleFor(s => s.UpdatedDate, f => f.Date.Recent())
        //            .RuleFor(s => s.IsDeleted, f => false)
        //            .RuleFor(a => a.Note, f => f.Lorem.Sentence());
        //        var list = fakers.Generate(count); // Tạo dữ liệu Assistant

        //        context.Set<>().AddRange(list); // Thêm vào cơ sở dữ liệu
        //        context.SaveChanges(); // Lưu thay đổi
        //    }
        //}

        //public static void Generate(DbContext context, int count)
        //{
        //    if (!context.Set<>().Any())
        //    {
        //        var fakers = new Faker<>()
        //            .RuleFor(a => a.Id, f => Guid.NewGuid())
        //            .RuleFor(a => a.Name, f => f.Name.FullName())
        //            .RuleFor(a => a.Location, f => f.Address.StreetAddress())
        //            .RuleFor(a => a.Price, f => f.Random.Decimal(100, 10000))
        //            .RuleFor(s => s.CreatedBy, f => "tsql@gmail.com")
        //            .RuleFor(s => s.CreatedDate, f => f.Date.Past(2))
        //            .RuleFor(s => s.UpdatedBy, f => "tsql@gmail.com")
        //            .RuleFor(s => s.UpdatedDate, f => f.Date.Recent())
        //            .RuleFor(s => s.IsDeleted, f => false)
        //            .RuleFor(a => a.Note, f => f.Lorem.Sentence());
        //        var list = fakers.Generate(count); // Tạo dữ liệu Assistant

        //        context.Set<>().AddRange(list); // Thêm vào cơ sở dữ liệu
        //        context.SaveChanges(); // Lưu thay đổi
        //    }
        //}

        //public static void Generate(DbContext context, int count)
        //{
        //    if (!context.Set<>().Any())
        //    {
        //        var fakers = new Faker<>()
        //            .RuleFor(a => a.Id, f => Guid.NewGuid())
        //            .RuleFor(a => a.Name, f => f.Name.FullName())
        //            .RuleFor(a => a.Location, f => f.Address.StreetAddress())
        //            .RuleFor(a => a.Price, f => f.Random.Decimal(100, 10000))
        //            .RuleFor(s => s.CreatedBy, f => "tsql@gmail.com")
        //            .RuleFor(s => s.CreatedDate, f => f.Date.Past(2))
        //            .RuleFor(s => s.UpdatedBy, f => "tsql@gmail.com")
        //            .RuleFor(s => s.UpdatedDate, f => f.Date.Recent())
        //            .RuleFor(s => s.IsDeleted, f => false)
        //            .RuleFor(a => a.Note, f => f.Lorem.Sentence());
        //        var list = fakers.Generate(count); // Tạo dữ liệu Assistant

        //        context.Set<>().AddRange(list); // Thêm vào cơ sở dữ liệu
        //        context.SaveChanges(); // Lưu thay đổi
        //    }
        //}


    }
}
