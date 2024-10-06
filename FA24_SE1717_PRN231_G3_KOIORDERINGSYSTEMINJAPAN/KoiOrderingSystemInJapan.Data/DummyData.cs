using Bogus;
using KoiOrderingSystemInJapan.Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KoiOrderingSystemInJapan.Data
{
    public static class DummyData
    {
        public static void SeedDatabase(DbContext context)
        {
            //GenerateCategories(context, 10);
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

        public static void GenerateFarm(DbContext context, int count)
        {
            if (!context.Set<Farm>().Any())
            {
                var fakers = new Faker<Farm>()
                    .RuleFor(a => a.Id, f => Guid.NewGuid())
                    .RuleFor(a => a.Name, f => f.Name.FullName())
                    .RuleFor(a => a.Address, f => f.Address.StreetAddress())
                    .RuleFor(a => a.Owner, f => f.Company.CompanyName())
                    .RuleFor(a => a.Phone, f => f.Phone.PhoneNumber())
                    .RuleFor(a => a., f => f.Phone.PhoneNumber()
                    .RuleFor(s => s.CreatedBy, f => "tsql@gmail.com")
                    .RuleFor(s => s.CreatedDate, f => f.Date.Past(2))
                    .RuleFor(s => s.UpdatedBy, f => "tsql@gmail.com")
                    .RuleFor(s => s.UpdatedDate, f => f.Date.Recent())
                    .RuleFor(s => s.IsDeleted, f => false)
                    .RuleFor(a => a.Note, f => f.Lorem.Sentence());
                var list = fakers.Generate(count); // Tạo dữ liệu Assistant

                context.Set<>().AddRange(list); // Thêm vào cơ sở dữ liệu
                context.SaveChanges(); // Lưu thay đổi
            }
        }

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
