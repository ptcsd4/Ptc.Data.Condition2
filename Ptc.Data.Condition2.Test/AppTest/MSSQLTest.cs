//using NUnit.Framework;
//using Ptc.Data.Condition2.Common;
//using Ptc.Data.Condition2.Common.Class;
//using Ptc.Data.Condition2.DataBase.MSSQL;
//using Ptc.Data.Condition2.Interface.Type;
//using Ptc.Data.Condition2.Mssql.Attribute;
//using Ptc.Data.Condition2.Mssql.Class;
//using Ptc.Data.Condition2.Mssql.Repository;
//using Ptc.Data.Condition2.Test.Automapper.HLH;
//using Ptc.Data.Condition2.Test.DI;
//using System;
//using System.Collections.Generic;
//using System.Data.Entity;
//using System.Linq;
//using System.Linq.Expressions;
//using System.Text;
//using System.Threading.Tasks;

//namespace Ptc.Data.Condition2.Test.StartupTest
//{

//    [TestFixture]
//    public class MSSQLTest
//    {
//        [OneTimeSetUp]
//        public void Setup()
//        {
//            Mssql.Common.MSSQLDataSetting mssetting = new Mssql.Common.MSSQLDataSetting()
//            {
//                DefaultDBContextDelegate = () =>
//                {
//                    return new OPMainEntities();
//                },
//                DefaultMappingConfig = () =>
//                {
//                    MapperContainer.SetConfig(HLHMapperConfig.HLH);
//                    return MapperContainer.Mapper;
//                }
//            };

//            DataAccessConfiguration.Configure(mssetting);

//            var config = DataAccessConfiguration.GetConfig(Interface.Type.DBStructureType.MSSQL);
//        }

//        [Test]
//        public void Mssql_NoConditions_WhenGet_ShouldNotNull()
//        {
//            var Repo_Of_SingleGeneric = DIBuilder.GetObject<IMSSQLRepository<Announcement>>();

//            DataBase.MSSQL.Announcement result_1 = Repo_Of_SingleGeneric.Get(x => x.ID == 187);

//            Assert.IsNotNull(result_1);
//            Assert.IsTrue(result_1.ID == 187);


//            var Repo_Of_PairGeneric = DIBuilder.GetObject<IMSSQLRepository<Announcement, Domain.Announcement>>();

//            Domain.Announcement result_2 = Repo_Of_PairGeneric.Get(x => x.ID == 187);

//            Assert.IsNotNull(result_2);
//            Assert.IsTrue(result_2.ID == 187);

//        }
//        [Test]
//        public void Mssql_HasConditions_WhenGet_ShouldNotNull()
//        {
//            var Repo_Of_SingleGeneric = DIBuilder.GetObject<IMSSQLRepository<Announcement>>();

//            var con1 = new MSSQLCondition<Announcement>();
//            con1.And(x => x.ID == 2231);
//            con1.IncludeBy(x => x.BranchCounter);
//            con1.IncludeBy(x => x.Coupon);

//            DataBase.MSSQL.Announcement result_1 = Repo_Of_SingleGeneric.Get(con1);

//            Assert.IsNotNull(result_1);
//            Assert.IsTrue(result_1.ID == 2231);


//            var Repo_Of_PairGeneric = DIBuilder.GetObject<IMSSQLRepository<Announcement, Domain.Announcement>>();

//            Domain.Announcement result_2 = Repo_Of_PairGeneric.Get(con1);

//            Assert.IsNotNull(result_2);
//            Assert.IsTrue(result_2.ID == 2231);

//        }
//        [Test]
//        public void Mssql_NoConditions_WhenGetAndOutMapping_ShouldEqual()
//        {

//            var Repo_Of_PairGeneric = DIBuilder.GetObject<IMSSQLRepository<Announcement, Domain.Coupon>>();


//            Domain.Coupon cou = Repo_Of_PairGeneric.Get((Announcement ann) => new Domain.Coupon()
//            {
//                AnnouncementID = ann.ID

//            }, x => x.ID == 2231);

//            Assert.IsTrue(cou.AnnouncementID == 2231);

//        }
//        [Test]
//        public void Mssql_HasConditions_WhenGetAndOutMapping_ShouldEqual()
//        {

//            var Repo_Of_PairGeneric = DIBuilder.GetObject<IMSSQLRepository<Announcement, int>>();

//            var con1 = new MSSQLCondition<Announcement>(x => x.ID == 2231);
//            con1.IncludeBy(x => x.BranchCounter);


//            int count = Repo_Of_PairGeneric.Get(con1, (Announcement ann) => ann.BranchCounter.Count());


//            Assert.IsTrue(count == 63);

//        }
//        [Test]
//        public void Mssql_NoConditions_WhenGetList_ShouldNotNull()
//        {
//            var Repo_Of_SingleGeneric = DIBuilder.GetObject<IMSSQLRepository<Announcement>>();

//            IEnumerable<DataBase.MSSQL.Announcement> result_1 = Repo_Of_SingleGeneric.GetList();

//            Assert.IsNotNull(result_1);

//            var Repo_Of_PairGeneric = DIBuilder.GetObject<IMSSQLRepository<Announcement, Domain.Announcement>>();

//            IEnumerable<Domain.Announcement> result_2 = Repo_Of_PairGeneric.GetList();

//            Assert.IsNotNull(result_2);

//            Assert.IsTrue(result_1.Count() == result_2.Count());

//        }
//        [Test]
//        public void Mssql_HasConditions_WhenGetList_ShouldNotNull()
//        {
//            var Repo_Of_SingleGeneric = DIBuilder.GetObject<IMSSQLRepository<Announcement>>();

//            var con1 = new MSSQLCondition<Announcement>();
//            con1.And(x => x.hasPushed == true);
//            con1.IncludeBy(x => x.BranchCounter);
//            con1.IncludeBy(x => x.Coupon);

//            IEnumerable<DataBase.MSSQL.Announcement> result_1 = Repo_Of_SingleGeneric.GetList(con1);

//            Assert.IsNotNull(result_1);

//            var Repo_Of_PairGeneric = DIBuilder.GetObject<IMSSQLRepository<Announcement, Domain.Announcement>>();

//            IEnumerable<Domain.Announcement> result_2 = Repo_Of_PairGeneric.GetList(con1);

//            Assert.IsNotNull(result_2);

//            Assert.IsTrue(result_1.Count() == result_2.Count());

//        }
//        [Test]
//        public void Mssql_HasConditions_WhenGetListAndOutMapping_ShouldEqual()
//        {

//            var Repo_Of_PairGeneric = DIBuilder.GetObject<IMSSQLRepository<Announcement, Domain.Coupon>>();

//            var con = new MSSQLCondition<Announcement>();

//            IEnumerable<Domain.Coupon> result = Repo_Of_PairGeneric.GetList(con, (Announcement ann) =>
//            {
//                return new Domain.Coupon()
//                {
//                    AnnouncementID = ann.ID
//                };
//            });

//        }
//        [Test]
//        public void Mssql_NoConditions_WhenGetListAndOutMapping_ShouldEqual()
//        {
//            var Repo_Of_PairGeneric = DIBuilder.GetObject<IMSSQLRepository<Announcement, Domain.Coupon>>();

//            var con = new MSSQLCondition<Announcement>();

//            IEnumerable<Domain.Coupon> result = Repo_Of_PairGeneric.GetList((Announcement ann) =>
//            {
//                return new Domain.Coupon()
//                {
//                    AnnouncementID = ann.ID
//                };
//            }, x => x.hasPushed == false);
//        }
//        [Test]
//        public void Mssql_NoCondition_HasAny_ShouldBeTrue()
//        {
//            var Repo_Of_SingleGeneric = DIBuilder.GetObject<IMSSQLRepository<Announcement>>();

//            var exist1 = Repo_Of_SingleGeneric.HasAny(x => x.IsPubilc == true);


//            var Repo_Of_PairGeneric = DIBuilder.GetObject<IMSSQLRepository<Announcement, Domain.Coupon>>();

//            var exist2 = Repo_Of_PairGeneric.HasAny(x => x.IsPubilc == true);

//            Assert.IsTrue(exist1);
//            Assert.IsTrue(exist2);

//        }
//        [Test]
//        public void Mssql_HasCondition_HasAny_ShouldBeFalse()
//        {
//            var Repo_Of_SingleGeneric = DIBuilder.GetObject<IMSSQLRepository<Announcement>>();

//            var con = new MSSQLCondition<Announcement>(x => x.ID == 99999);

//            var exist1 = Repo_Of_SingleGeneric.HasAny(con);

//            var Repo_Of_PairGeneric = DIBuilder.GetObject<IMSSQLRepository<Announcement, Domain.Coupon>>();

//            var exist2 = Repo_Of_PairGeneric.HasAny(con);


//            Assert.IsFalse(exist1);
//            Assert.IsFalse(exist2);
//        }
//        [Test]
//        public void Mssql_GetListOfSpecific_ShouldMatch()
//        {
//            var Repo_Of_PairGeneric = DIBuilder.GetObject<IMSSQLRepository<ActivityItem, Coupon>>();

//            Repo_Of_PairGeneric.OverrideDBContext(() => new OPMainEntities());

//            var con = new MSSQLCondition<ActivityItem>(x => x.LastUpdateTime < DateTime.Now);

//            List<Coupon> objs = Repo_Of_PairGeneric.GetListOfSpecific(con, x => new Coupon()
//            {
//                ActiveEndDate = x.EndDate,
//                ActiveStartDate = x.StartDate
//            });

//        }
//        [Test]
//        public void Mssql_GetSpecific_ShouldMatch()
//        {
//            var Repo_Of_PairGeneric = DIBuilder.GetObject<IMSSQLRepository<ActivityItem, Coupon>>();

//            Repo_Of_PairGeneric.OverrideDBContext(() => new OPMainEntities());

//            var con = new MSSQLCondition<ActivityItem>(x => x.Code == "1808300001");

//            Coupon objs = Repo_Of_PairGeneric.GetOfSpecific(con, x => new Coupon()
//            {
//                ActiveEndDate = x.EndDate,
//                ActiveStartDate = x.StartDate
//            });

//        }

//        [Test]
//        public void Mssql_OverrideDB_WhenCallOperator_ShouldMatch()
//        {
//            var Repo_Of_SingleGeneric = DIBuilder.GetObject<IMSSQLRepository<Announcement>>();

//            Repo_Of_SingleGeneric.OverrideDBContext(() => new HLHApp_DemoEntities());

//            Repo_Of_SingleGeneric.Operator((hlh) =>
//            {


//                var del = LambdaUtility.FuncToExpression<Announcement, Announcement>((Announcement) =>
//                {

//                    Announcement.BranchCounter = Announcement.BranchCounter.Where(x => x.AddressCityID == 5).ToList();
//                    return Announcement;
//                });

//                var query = ((HLHApp_DemoEntities)hlh).Announcement.AsQueryable().AsNoTracking();

//                var test = query.Include(x => x.BranchCounter)
//                                .Where(x => x.BranchCounter.Count > 0)
//                                .Select(del.Compile())
//                                .ToList();
//            });


//        }
//        [Test]
//        public void Mssql_OverrideDB_WhenCallOperatorAndReuturn_ShouldMatch()
//        {
//            var Repo_Of_PairGeneric = DIBuilder.GetObject<IMSSQLRepository<ActivityItem, List<ActivityItem>>>();

//            Repo_Of_PairGeneric.OverrideDBContext(() => new OPMainEntities());

//            List<ActivityItem> result = Repo_Of_PairGeneric.Operator((op) =>
//            {

//                var query = ((OPMainEntities)op).ActivityItem.AsQueryable().AsNoTracking();

//                return query.ToList();

//            });
//        }
//        [Test]
//        public void Mssql_NoConditions_WhenGetPaging_ShouldNotNull()
//        {
//            var Repo_Of_SingleGeneric = DIBuilder.GetObject<IMSSQLRepository<Announcement>>();

//            var con = new MSSQLCondition<Announcement>(1, 20);
//            con.OrderBy(x => x.ID, OrderType.Asc);
//            PagedList<Announcement> result_1 = Repo_Of_SingleGeneric.GetPaging(con);

//            Assert.IsNotNull(result_1);
//            Assert.True(result_1.Count == 20);

//            var Repo_Of_PairGeneric = DIBuilder.GetObject<IMSSQLRepository<Announcement, Domain.Announcement>>();

//            PagedList<Domain.Announcement> result_2 = Repo_Of_PairGeneric.GetPaging(con);

//            Assert.IsNotNull(result_2);
//            Assert.True(result_2.Count == 20);

//        }
//        [Test]
//        public void Mssql_NoConditions_WhenGetPagingAndOutMapping_ShouldNotNull()
//        {
//            var Repo_Of_SingleGeneric = DIBuilder.GetObject<IMSSQLRepository<Announcement>>();

//            var con = new MSSQLCondition<Announcement>(1, 20);
//            con.OrderBy(x => x.ID, OrderType.Asc);
//            con.OrderBy(x => x.hasPushed, OrderType.Desc);
//            PagedList<Announcement> result_1 = Repo_Of_SingleGeneric.GetPaging(con);

//            Assert.IsNotNull(result_1);
//            Assert.True(result_1.Count == 20);

//            var Repo_Of_PairGeneric = DIBuilder.GetObject<IMSSQLRepository<Announcement, int>>();

//            IEnumerable<int> result_2 = Repo_Of_PairGeneric.GetPaging(con, x => x.ID);

//            Assert.IsNotNull(result_2);
//            Assert.True(result_2.Count() == 20);

//        }
//        [Test]
//        public void Mssql_HasConditions_WhenUpdate_ShouldBeTrue()
//        {
//            var Repo_Of_PairGeneric = DIBuilder.GetObject<IMSSQLRepository<Announcement, Domain.Announcement>>();

//            var con = new MSSQLCondition<Announcement>(x => x.ID == 3292);
//            con.IncludeBy(x => x.Coupon);
//            con.IncludeBy(x => x.BranchCounter);
//            con.IncludeBy(x => x.MachineType);

//            con.Modify(x => x.Content);
//            con.Modify(x => x.Title);
//            con.Modify(x => x.PostStartDate);
//            con.Modify(x => x.MachineType, EntityState.Unchanged);
//            con.Modify(x => x.Coupon, EntityState.Modified);
//            con.Modify(x => x.BranchCounter, EntityState.Unchanged);


//            var payload = new Domain.Announcement()
//            {
//                ID = 3292,
//                Content = "dddQWEdd",
//                Title = "aWWRWRaa",
//                PostStartDate = DateTime.Now.AddMonths(1),
//                BranchCounter = new List<Domain.BranchCounter>()
//                    {
//                        new Domain.BranchCounter(){
//                            BranchCounterID = 31
//                        },
//                         new Domain.BranchCounter(){
//                            BranchCounterID = 32
//                        },
//                    },
//                MachineType = new List<Domain.MachineType>() {
//                    new Domain.MachineType(){
//                        MachineTypeID = "100",
//                        BrandID = "2",
//                    },
//                    new Domain.MachineType(){
//                        MachineTypeID = "101",
//                        BrandID = "2",
//                    }


//                },
//                Coupon = new Domain.Coupon()
//                {
//                    AnnouncementID = 3292,
//                    DescriptionOfUse = "xsssx",
//                    DescriptionOfOther = "xxsssa",
//                    ActiveEndDate = DateTime.Now,
//                    ActiveStartDate = DateTime.Now,
//                    ExchangeEndDate = DateTime.Now,
//                    ExchangeStartDate = DateTime.Now
//                }


//            };



//            //var Repo_Of_PairGeneric = DIBuilder.GetObject<IMSSQLRepository<Announcement>>();

//            //var con = new MSSQLCondition<Announcement>(x => x.ID == 3290);
//            //con.IncludeBy(x => x.Coupon);
//            ////con.IncludeBy(x => x.BranchCounter);
//            //// con.IncludeBy(x => x.MachineType);

//            //con.Modify(x => x.Content);
//            //con.Modify(x => x.Title);
//            //con.Modify(x => x.PostStartDate);
//            //// con.Modify(x => x.MachineType, EntityState.Unchanged);
//            //con.Modify(x => x.Coupon, EntityState.Modified);
//            //// con.Modify(x => x.BranchCounter, EntityState.Unchanged);


//            //var payload = new Announcement()
//            //{
//            //    ID = 3290,
//            //    Content = "dddQWEdd",
//            //    Title = "aWWRWRaa",
//            //    PostStartDate = DateTime.Now.AddMonths(1),

//            //    Coupon = new Coupon()
//            //    {
//            //        AnnouncementID = 3290,
//            //        DescriptionOfUse = "xsssx",
//            //        DescriptionOfOther = "xxsssa",
//            //        ActiveEndDate = DateTime.Now,
//            //        ActiveStartDate = DateTime.Now,
//            //        ExchangeEndDate = DateTime.Now,
//            //        ExchangeStartDate = DateTime.Now
//            //    }


//            //};

//            var result = Repo_Of_PairGeneric.Update(con, payload);

//        }
//        [Test]
//        public void Mssql_NoConditions_WhenAdd_ShoudBrTrue()
//        {

//            //var Repo_Of_PairGeneric = DIBuilder.GetObject<IMSSQLRepository<Announcement, Domain.Announcement>>();

//            //var payload = new Domain.Announcement()
//            //{
//            //    Title = "PTC_DATA2",
//            //    PreviewImagePath = "PTC_DATA2",
//            //    PostStartDate = DateTime.Now,
//            //    PostEndDate = DateTime.Now,
//            //    CreateDate = DateTime.Now,
//            //    NoticeType = "[]",
//            //    UpdateDate = DateTime.Now,
//            //    IsPerformance = true,
//            //    hasPushed = false,
//            //    IsPubilc = true,
//            //    DescriptionOfAddressIsURL = false,
//            //    AnnouncementType = 1,
//            //    Coupon = new Domain.Coupon()
//            //    {
//            //        DescriptionOfUse = "fuck",
//            //        DescriptionOfOther = "fuck1",
//            //        ActiveEndDate = DateTime.Now,
//            //        ActiveStartDate = DateTime.Now,
//            //        ExchangeEndDate = DateTime.Now,
//            //        ExchangeStartDate = DateTime.Now
//            //    },


//            //};

//            //var result = Repo_Of_PairGeneric.Add(payload);

//            var Repo_Of_SingleGeneric = DIBuilder.GetObject<IMSSQLRepository<Announcement>>();

//            var payload1 = new Announcement()
//            {
//                Title = "PTC_DATA2_3",
//                PreviewImagePath = "PTC_DATA2_3",
//                PostStartDate = DateTime.Now,
//                PostEndDate = DateTime.Now,
//                CreateDate = DateTime.Now,
//                NoticeType = "[]",
//                UpdateDate = DateTime.Now,
//                IsPerformance = true,
//                hasPushed = false,
//                IsPubilc = true,
//                DescriptionOfAddressIsURL = false,
//                AnnouncementType = 1,
//                Coupon = new Coupon()
//                {
//                    DescriptionOfUse = "fuck",
//                    DescriptionOfOther = "fuck1",
//                    ActiveEndDate = DateTime.Now,
//                    ActiveStartDate = DateTime.Now,
//                    ExchangeEndDate = DateTime.Now,
//                    ExchangeStartDate = DateTime.Now
//                },


//            };

//            Repo_Of_SingleGeneric.Add(payload1);

//        }
//        [Test]
//        public void Mssql_NoConditions_WhenAddAndMapper_ShouldBeTrue()
//        {
//            var Repo_Of_PairGeneric = DIBuilder.GetObject<IMSSQLRepository<Announcement, Domain.Announcement>>();

//            var payload = new Domain.Announcement()
//            {
//                Title = "PTC_DATA2_1",
//                PreviewImagePath = "PTC_DATA2_1",
//                PostStartDate = DateTime.Now,
//                PostEndDate = DateTime.Now,
//                CreateDate = DateTime.Now,
//                NoticeType = "[]",
//                UpdateDate = DateTime.Now,
//                IsPerformance = true,
//                hasPushed = false,
//                IsPubilc = true,
//                DescriptionOfAddressIsURL = false,
//                AnnouncementType = 1,
//                Coupon = new Domain.Coupon()
//                {
//                    DescriptionOfUse = "fuck",
//                    DescriptionOfOther = "fuck1",
//                    ActiveEndDate = DateTime.Now,
//                    ActiveStartDate = DateTime.Now,
//                    ExchangeEndDate = DateTime.Now,
//                    ExchangeStartDate = DateTime.Now
//                },


//            };

//            var id = Repo_Of_PairGeneric.Add(payload, null, x => x.ID);


//        }
//        [Test]
//        public void Mssql_HasConditions_WhenAddExistRef_ShouldBeTrue()
//        {
//            //var Repo_Of_PairGeneric = DIBuilder.GetObject<IMSSQLRepository<Announcement, Domain.Announcement>>();

//            //var con = new MSSQLCondition<Announcement>();
//            //con.Modify(x => x.Coupon, EntityState.Added);
//            //con.Modify(x => x.MachineType, EntityState.Unchanged);
//            //con.Modify(x => x.BranchCounter, EntityState.Unchanged);



//            //var payload = new Domain.Announcement()
//            //{
//            //    Title = "PTC_DATA2_1_2",
//            //    PreviewImagePath = "PTC_DATA2_1_2",
//            //    PostStartDate = DateTime.Now,
//            //    PostEndDate = DateTime.Now,
//            //    CreateDate = DateTime.Now,
//            //    NoticeType = "[]",
//            //    UpdateDate = DateTime.Now,
//            //    IsPerformance = true,
//            //    hasPushed = false,
//            //    IsPubilc = true,
//            //    DescriptionOfAddressIsURL = false,
//            //    AnnouncementType = 1,
//            //    Coupon = new Domain.Coupon()
//            //    {

//            //        DescriptionOfUse = "fuck2",
//            //        DescriptionOfOther = "fuck13",
//            //        ActiveEndDate = DateTime.Now,
//            //        ActiveStartDate = DateTime.Now,
//            //        ExchangeEndDate = DateTime.Now,
//            //        ExchangeStartDate = DateTime.Now
//            //    },

//            //    MachineType = new List<Domain.MachineType>() {
//            //        new Domain.MachineType(){
//            //            MachineTypeID = "100",
//            //            BrandID = "2",
//            //        },
//            //        new Domain.MachineType(){
//            //            MachineTypeID = "101",
//            //            BrandID = "2",
//            //        }


//            //    },
//            //    BranchCounter = new List<Domain.BranchCounter>()
//            //        {
//            //            new Domain.BranchCounter(){
//            //                BranchCounterID = 31
//            //            },
//            //             new Domain.BranchCounter(){
//            //                BranchCounterID = 32
//            //            },
//            //        }


//            //};


//            var Repo_Of_SingleGeneric = DIBuilder.GetObject<IMSSQLRepository<Announcement>>();

//            var con = new MSSQLCondition<Announcement>();
//            con.Modify(x => x.Coupon, EntityState.Added);
//            con.Modify(x => x.MachineType, EntityState.Unchanged);
//            con.Modify(x => x.BranchCounter, EntityState.Unchanged);



//            var payload = new Announcement()
//            {
//                Title = "PTC_DATA2_1_2_3",
//                PreviewImagePath = "PTC_DATA2_1_2_3",
//                PostStartDate = DateTime.Now,
//                PostEndDate = DateTime.Now,
//                CreateDate = DateTime.Now,
//                NoticeType = "[]",
//                UpdateDate = DateTime.Now,
//                IsPerformance = true,
//                hasPushed = false,
//                IsPubilc = true,
//                DescriptionOfAddressIsURL = false,
//                AnnouncementType = 1,
//                Coupon = new Coupon()
//                {

//                    DescriptionOfUse = "fuck2",
//                    DescriptionOfOther = "fuck13",
//                    ActiveEndDate = DateTime.Now,
//                    ActiveStartDate = DateTime.Now,
//                    ExchangeEndDate = DateTime.Now,
//                    ExchangeStartDate = DateTime.Now
//                },

//                MachineType = new List<MachineType>() {
//                    new MachineType(){
//                        MachineTypeID = "100",
//                        BrandID = "2",
//                    },
//                    new MachineType(){
//                        MachineTypeID = "101",
//                        BrandID = "2",
//                    }


//                },
//                BranchCounter = new List<BranchCounter>()
//                    {
//                        new BranchCounter(){
//                            BranchCounterID = 31
//                        },
//                         new BranchCounter(){
//                            BranchCounterID = 32
//                        },
//                    }


//            };

//            var result = Repo_Of_SingleGeneric.Add(con, payload);
//        }
//        [Test]
//        public void Mssql_NoConditions_WhenAddRange_ShouldBeTrue()
//        {
//            var Repo_Of_PairGeneric = DIBuilder.GetObject<IMSSQLRepository<MachineType, Domain.MachineType>>();

//            var payload = new List<Domain.MachineType>()
//            {
//                new Domain.MachineType(){
//                    MachineTypeID = "199",
//                    BrandID = "1",

//                },
//                  new Domain.MachineType(){
//                    MachineTypeID = "200",
//                    BrandID = "1",

//                },

//            };

//            var result = Repo_Of_PairGeneric.AddRange(payload);

//        }
//        [Test]
//        public void Mssql_NoConditions_WhenAddRangeWithMapper_ShouldBeTrue()
//        {
//            var Repo_Of_PairGeneric = DIBuilder.GetObject<IMSSQLRepository<MachineType, Domain.MachineType>>();

//            var payload = new List<Domain.MachineType>()
//            {
//                new Domain.MachineType(){
//                    MachineTypeID = "196",
//                    BrandID = "1",

//                },
//                  new Domain.MachineType(){
//                    MachineTypeID = "196",
//                    BrandID = "2",

//                },

//            };

//            var result = Repo_Of_PairGeneric.AddRange(payload, null, x => new
//            {

//                a = x.MachineTypeID,
//                b = x.BrandID

//            });

//        }
//        [Test]
//        public void Mssql_WhenCallRemove_ShouldBeTrue()
//        {
//            //var Repo_Of_PairGeneric = DIBuilder.GetObject<IMSSQLRepository<Announcement, Domain.Announcement>>();

//            //var con = new MSSQLCondition<Announcement>(x=>x.ID == 3289);
//            //con.IncludeBy(x => x.BranchCounter);
//            //con.IncludeBy(x => x.Coupon);
//            //con.IncludeBy(x => x.MachineType);


//            //Repo_Of_PairGeneric.Remove(con);

//            var Repo_Of_SingleGeneric = DIBuilder.GetObject<IMSSQLRepository<Announcement>>();

//            var con = new MSSQLCondition<Announcement>(x => x.ID == 3291);
//            con.IncludeBy(x => x.BranchCounter);
//            con.IncludeBy(x => x.Coupon);
//            con.IncludeBy(x => x.MachineType);


//            Repo_Of_SingleGeneric.Remove(con);


//        }
//        [Test]
//        public void Mssql_WhenCallRemoveRange_ShouldBeTrue()
//        {
//            //var Repo_Of_PairGeneric = DIBuilder.GetObject<IMSSQLRepository<Announcement, Domain.Announcement>>();

//            //int[] term = new int[] {
//            //    3288 , 3287 , 3286
//            //};

//            //var con = new MSSQLCondition<Announcement>(x => term.Contains(x.ID));
//            //con.IncludeBy(x => x.BranchCounter);
//            //con.IncludeBy(x => x.Coupon);
//            //con.IncludeBy(x => x.MachineType);


//            //Repo_Of_PairGeneric.RemoveRange(con);


//            var Repo_Of_SingleGeneric = DIBuilder.GetObject<IMSSQLRepository<Announcement>>();

//            int[] term = new int[] {
//                3285 , 3284 , 3282
//            };

//            var con = new MSSQLCondition<Announcement>(x => term.Contains(x.ID));
//            con.IncludeBy(x => x.BranchCounter);
//            con.IncludeBy(x => x.Coupon);
//            con.IncludeBy(x => x.MachineType);


//            Repo_Of_SingleGeneric.RemoveRange(con);


//        }

//        [Test]
//        public void testfillpayload()
//        {
//            var s = new BrandViewModel()
//            {
             
//            };

//            MSSQLCondition<Brand> condition = new MSSQLCondition<Brand>(new List<BrandViewModel>() { s }, 0, 5);

//            //condition.OrderBy(x=>x.ID, 0);
//            condition.OrderBy("ID", OrderType.Asc);
//            condition.OrderBy("StartDate", OrderType.Desc);
//            //condition.IncludeBy("Item");
//            //condition.Modify("Item", 0);

//            var Repo_Of_SingleGeneric = DIBuilder.GetObject<IMSSQLRepository<Brand , int>>();

//            var r = Repo_Of_SingleGeneric.GetPaging(condition);

//        }

//        public class BrandViewModel
//        {

//            public BrandViewModel() { }


//            [MSSQLFilter("Name",
//            ExpressionType.Parameter,
//            PredicateType.And)]
//            public string Name { get; set; }

//            [MSSQLFilter("IsDisabled",
//            ExpressionType.Equal,
//            PredicateType.And)]
//            public bool? IsDisabled { get; set; }

//            [MSSQLFilter("IsHaveStore",
//            ExpressionType.Equal,
//            PredicateType.And)]
//            public bool? IsHaveStore { get; set; }

//        }


//    }
//}
