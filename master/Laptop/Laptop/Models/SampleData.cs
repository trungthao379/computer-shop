using Laptop;
using Laptop.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace LaptopOnline.Models
{
    public class SampleData : DropCreateDatabaseIfModelChanges<LaptopEntities>
    {
        protected override void Seed(LaptopEntities context)
        {
            Database.SetInitializer(new DropCreateDatabaseIfModelChanges<LaptopEntities>());

            var manufacturer = new List<Manufacturer>
            {
                new Manufacturer{
                    manufacturerID=1,
                    manufacturerName="DELL"
                },
                new Manufacturer{
                    manufacturerID=2,
                    manufacturerName="ASUS"
                },
                new Manufacturer{
                    manufacturerID=3,
                    manufacturerName="VAIO"
                },
                new Manufacturer{
                    manufacturerID=4,
                    manufacturerName="ACER"
                },
                new Manufacturer{
                    manufacturerID=5,
                    manufacturerName="MACBOOK"
                },
                new Manufacturer{
                    manufacturerID=6,
                    manufacturerName="HP"
                },
                new Manufacturer{
                    manufacturerID=7,
                    manufacturerName="Lenovo"
                }
                
            };
            manufacturer.ForEach(s => context.Manufacturers.Add(s));
            context.SaveChanges();



            //Screen
            var screen = new List<Screen>
            {
                new Screen{
                    screenID=1,
                    screenName="HP LCD 14.0inch LED HP 1000",
                    manufacturer="Hewlett-Parkard (HP)",
                    size="14 inch",
                    touchScreen=false,
                    resolution="1366 x 768",
                    isNoLonger=false,
                    type="Unknown"
                    
                },

                new Screen{
                    screenID=2,
                    screenName="Màn hình Dell D820, D830",
                    manufacturer="AUO",
                    size="15.4 inch",
                    touchScreen=false,
                    resolution="1366 x 768",
                    isNoLonger=false,
                    type="Unknown"
                },

                new Screen{
                    screenID=3,
                    screenName="IBM Thinkpad ",
                    manufacturer="IBM",
                    size="14.1 inch",
                    touchScreen=false,
                    resolution="1400 x 1050",
                    isNoLonger=false,
                    type="Unknown"
                }
            };
            screen.ForEach(s => context.Screens.Add(s));
            context.SaveChanges();
            //CPU
            var cpu = new List<CPU>
            {
                new CPU{
                    cpuID=1,
                    cpuName="Intel Core i5-460M",
                    cpuType="Core i5",
                    speed="2.53GHz (Max Turbo Frequency 2.8GHz)",
                    technology="32nm",
                    isNoLonger=false,
                    manufacturer="INTEL",
                    
                },
                new CPU{
                    cpuID=2,
                    cpuName="Intel Core i5-450M",
                    cpuType="Core i5",
                    speed="2.4GHz (Max Turbo Frequency 2.66GHz)",
                    technology="32nm",
                    isNoLonger=false,
                    manufacturer="INTEL",
                   
                },
                new CPU{
                    cpuID=3,
                    cpuName="Intel Core i7-720QM",
                    cpuType="Core i5",
                    speed="1.6GHz (Max Turbo Frequency 2.8GHz)",
                    technology="45nm",
                    isNoLonger=false,
                    manufacturer="INTEL",
                   
                }
            };
            cpu.ForEach(s => context.CPUs.Add(s));
            context.SaveChanges();
            //Graphics
            var graphic = new List<Graphic>
            {
                new Graphic{
                    graphicID=1,
                    graphicName="VGA 1GB Gigabyte R545 - 1GI",
                    graphicType="Unknown",
                    isNoLonger=false,
                    manufacturer="GIGABYTE"     
                },
                new Graphic{
                    graphicID=2,
                    graphicName="VGA 1GB Gigabyte N210D3 - 1GI",
                    graphicType="Unknown",
                    isNoLonger=false,
                    manufacturer="GIGABYTE"
                },
                 new Graphic{
                    graphicID=3,
                    graphicName="VGA 1GB Asus EN210 Silent/ DI/ 1GD3/ V2 (LP)",
                    graphicType="Unknown",
                    isNoLonger=false,
                    manufacturer="ASUS"
                }
            };
            graphic.ForEach(s => context.Graphics.Add(s));
            context.SaveChanges();

            //HardDrives
            var harddrive = new List<HardDrive>
            {
                new HardDrive{
                    hardDriveID=1,
                    hardDriveName="Seagate 320GB - 7200rpm - 16MB Cache - SATA 2",
                    diskSpace="320GB",
                    hardDriveType=1,
                    isNoLonger=false,
                    manufacturer="Seagate"
                },
                new HardDrive{
                    hardDriveID=2,
                    hardDriveName="Hitachi 500GB - 5400rpm - 8MB cache - SATA - 2.5inch",
                    diskSpace="500GB",
                    hardDriveType=1,
                    isNoLonger=false,
                    manufacturer="Hitachi"
                }
            };
            //Products
            var products = new List<Product>
            {
                new Product{ 
                    productID=1,
                    productName="Dell-inspiron-3542",
                    productType="DELL", 
                    Manufacturer=manufacturer.Single(g=>g.manufacturerID==1),
                    longDescription="Thiết kế mới với thân máy vuông vức mạnh mẽ và nam tính nhưng các cạnh máy được bo tròn mềm mại tạo cảm giác mỏng và thanh lịch hơn.",
                    shortDescription="Thiết kế mới với thân máy vuông vức mạnh mẽ và nam tính nhưng các cạnh máy được bo tròn mềm mại tạo cảm giác mỏng và thanh lịch hơn.",
                    imageSrc="Dell-Inspiron-3542.jpg",
                    warrantyPeriod="16-09-09",
                    CPU=cpu.Single(g=>g.cpuID==2),
                    HardDrive=harddrive.Single(g=>g.hardDriveID==1),
                    Screen=screen.Single(g=>g.screenID==2),
                    Graphic=graphic.Single(g=>g.graphicID==2),
                    cd_DVD="DVD Super Multi Double Layer",
                    camera="HD Webcam, 0.9 MP", 
                    wifi="802.11b/g/n",     
                    os="Linux",
                    battery="Li-Ion-6 cell",
                    ram="DDR3L(2 khe RAM),4GB",   
                    unitPrice=11290000,
                    isNoLonger=false,
                    isNew=true,
                    isHot=true,
                    isSale=false,
                    quantity=10,
                    importPrice=11290000,
                    
                    
                },
                new Product{ 
                    productID=2,
                    productName="Dell-Inspiron-3537",
                    productType="DELL", 
                    Manufacturer=manufacturer.Single(g=>g.manufacturerID==1),
                    longDescription="Thiết kế với vỏ nhựa được phủ màu đen sang trọng, bề mặt ngoài cũng như các cạnh viền bên trong của máy được khắc theo họa tiết kim cương vì vậy mà máy có khả năng chống bám bụi rất tốt, nhìn rất thích mắt..",
                    shortDescription="Thiết kế với vỏ nhựa được phủ màu đen sang trọng, bề mặt ngoài cũng như các cạnh viền bên trong của máy được khắc theo họa tiết kim cương vì vậy mà máy có khả năng chống bám bụi rất tốt, nhìn rất thích mắt.",
                    imageSrc="dell-inspiron-3537.jpg",
                    warrantyPeriod="16-09-09",
                    CPU=cpu.Single(g=>g.cpuID==1),
                    HardDrive=harddrive.Single(g=>g.hardDriveID==2),
                    Screen=screen.Single(g=>g.screenID==2),
                    Graphic=graphic.Single(g=>g.graphicID==2),
                    cd_DVD="DVD Super Multi Double Layer",
                    camera="HD Webcam, 0.9 MP", 
                    wifi="802.11b/g/n",     
                    os="Linux",
                    battery="Li-Ion-6 cell",
                    ram="DDR3L(1 khe RAM),4GB",   
                    unitPrice=12490000,
                    isNoLonger=false,
                    isNew=true,
                    isHot=true,
                    isSale=false,
                    quantity=10,
                    importPrice=11000000,
                    
                },
                new Product{ 
                    productID=3,
                    productName="Dell Vostro 5560",
                    productType="DELL", 
                    Manufacturer=manufacturer.Single(g=>g.manufacturerID==1),
                    longDescription="Với bộ khung vỏ nhôm chắc chắn cùng thiết kế mỏng nhẹ, chỉ dày 21 mm và nặng 2.2 kg vì thế trông Dell Vostro 5560 rất sang trọng và lịch lãm. Viền màn hình của máy cũng rất mỏng, tạo cảm giác cao cấp và hiện đại.",
                    shortDescription="Với bộ khung vỏ nhôm chắc chắn cùng thiết kế mỏng nhẹ, chỉ dày 21 mm và nặng 2.2 kg vì thế trông Dell Vostro 5560 rất sang trọng và lịch lãm. Viền màn hình của máy cũng rất mỏng, tạo cảm giác cao cấp và hiện đại.",
                    imageSrc="Dell-Vostro-5560.jpg",
                    warrantyPeriod="16-09-09",
                    CPU=cpu.Single(g=>g.cpuID==1),
                    HardDrive=harddrive.Single(g=>g.hardDriveID==2),
                    Screen=screen.Single(g=>g.screenID==2),
                    Graphic=graphic.Single(g=>g.graphicID==2),
                    cd_DVD="DVD Super Multi Double Layer",
                    camera="HD Webcam, 0.9 MP", 
                    wifi="802.11b/g/n",     
                    os="Linux",
                    battery="Li-Ion-6 cell",
                    ram="DDR3L(1 khe RAM),4GB",   
                    unitPrice=14490000,
                    isNoLonger=false,
                    isNew=true,
                    isHot=true,
                    isSale=false,
                    quantity=10,
                    importPrice=11000000,
                    
                    
                   
                },
                new Product{ 
                    productID=4,
                    productName="ACER E1-470",
                    productType="ACER", 
                    Manufacturer=manufacturer.Single(g=>g.manufacturerID==4),
                    longDescription="Là một thiết bị mang sự kết hợp tuyệt vời giữa hiệu suất làm việc và khả năng di động, và mức giá khá hấp dẫn của sản phẩm.",
                    shortDescription="Là một thiết bị mang sự kết hợp tuyệt vời giữa hiệu suất làm việc và khả năng di động, và mức giá khá hấp dẫn của sản phẩm.",
                    imageSrc="Acer-Aspire-E1-470.jpg",
                    warrantyPeriod="16-09-09",
                    CPU=cpu.Single(g=>g.cpuID==1),
                    HardDrive=harddrive.Single(g=>g.hardDriveID==2),
                    Screen=screen.Single(g=>g.screenID==2),
                    Graphic=graphic.Single(g=>g.graphicID==2),
                    cd_DVD="DVD Super Multi Double Layer",
                    camera="HD Webcam, 0.9 MP", 
                    wifi="802.11b/g/n",     
                    os="Linux",
                    battery="Li-Ion-6 cell",
                    ram="DDR3L(1 khe RAM),4GB",   
                    unitPrice=7990000,
                    isNoLonger=false,
                    isNew=true,
                    isHot=true,
                    isSale=false,
                    quantity=10,
                    importPrice=11000000,
                    
                },
                new Product{ 
                    productID=5,
                    productName="ACER E1-470G",
                    productType="ACER", 
                    Manufacturer=manufacturer.Single(g=>g.manufacturerID==4),
                    longDescription="Cầm trong tay sản phẩm Aspire E1 470G bạn có thể bị thu hút ngay bởi màu đen sáng bóng từ lớp vỏ nhựa cao cấp cùng các đường nét thiết kế rất cổ điển mang đậm phong cách của Acer. Không những vậy, máy còn được trang bị một phần cứng khá tốt đáp ứng được mọi nhu cầu đa dạng của người dùng.",
                    shortDescription="Cầm trong tay sản phẩm Aspire E1 470G bạn có thể bị thu hút ngay bởi màu đen sáng bóng từ lớp vỏ nhựa cao cấp cùng các đường nét thiết kế rất cổ điển mang đậm phong cách của Acer. Không những vậy, máy còn được trang bị một phần cứng khá tốt đáp ứng được mọi nhu cầu đa dạng của người dùng.",
                    imageSrc="Acer-Aspire-E1-470G.jpg",
                    warrantyPeriod="16-09-09",
                    CPU=cpu.Single(g=>g.cpuID==1),
                    HardDrive=harddrive.Single(g=>g.hardDriveID==2),
                    Screen=screen.Single(g=>g.screenID==2),
                    Graphic=graphic.Single(g=>g.graphicID==2),
                    cd_DVD="DVD Super Multi Double Layer",
                    camera="HD Webcam, 0.9 MP", 
                    wifi="802.11b/g/n",     
                    os="Linux",
                    battery="Li-Ion-6 cell",
                    ram="DDR3L(1 khe RAM),4GB",   
                    unitPrice=8990000,
                    isNoLonger=false,
                    isNew=true,
                    isHot=false,
                    isSale=false,
                    quantity=10,
                    importPrice=11000000,
                    
                },
                new Product{ 
                    productID=6,
                    productName="ACER-Aspire-E5-471",
                    productType="ACER", 
                    Manufacturer=manufacturer.Single(g=>g.manufacturerID==4),
                    longDescription="Là một sản phẩm thuộc dòng laptop phổ thông của Acer, thiết bị không chỉ có giá hấp dẫn mà nó còn được trang bị bên trong phần cấu hình khá tốt, đáng chú ý đó là chip xử lý Core i5 thế hệ Haswell của Intel, hỗ trợ RAM 4GB, với màn hình 14 inch, chất lượng hiển thị tốt, Acer Aspire E5 471 thích hợp với nhu cầu giải trí nhẹ nhàng, lướt web, xem phim và làm việc hàng ngày.",
                    shortDescription="Là một sản phẩm thuộc dòng laptop phổ thông của Acer, thiết bị không chỉ có giá hấp dẫn mà nó còn được trang bị bên trong phần cấu hình khá tốt, đáng chú ý đó là chip xử lý Core i5 thế hệ Haswell của Intel, hỗ trợ RAM 4GB, với màn hình 14 inch, chất lượng hiển thị tốt, Acer Aspire E5 471 thích hợp với nhu cầu giải trí nhẹ nhàng, lướt web, xem phim và làm việc hàng ngày.",
                    imageSrc="ACER-Aspire-E5-471.jpg",
                    warrantyPeriod="16-09-09",
                    CPU=cpu.Single(g=>g.cpuID==1),
                    HardDrive=harddrive.Single(g=>g.hardDriveID==2),
                    Screen=screen.Single(g=>g.screenID==2),
                    Graphic=graphic.Single(g=>g.graphicID==2),
                    cd_DVD="DVD Super Multi Double Layer",
                    camera="HD Webcam, 0.9 MP", 
                    wifi="802.11b/g/n",     
                    os="Linux",
                    battery="Li-Ion-6 cell",
                    ram="DDR3L(1 khe RAM),4GB",   
                    unitPrice=9990000,
                    isNoLonger=false,
                    isNew=true,
                    isHot=false,
                    isSale=false,
                    quantity=10,
                    importPrice=11000000,
                    
                },
                new Product{ 
                    productID=7,
                    productName="Macbook Air MD760",
                    productType="MACBOOK", 
                    Manufacturer=manufacturer.Single(g=>g.manufacturerID==5),
                    longDescription="Như một món quà dành cho người dùng, Macbook Air 13 inch 2014 được tung ra thị trường với một chút nâng cấp nhẹ nhàng phần cứng, tăng thời lượng pin và hấp dẫn nhất là giá cả đã được Apple “hạ nhiệt” đôi chút. Sản phẩm vẫn sở hữu thân hình đầy quyến rũ khi được giữ nguyên lớp vỏ nhôm nguyên khối, đường nét thiết kế chuyên nghiệp và tỉ mỉ đến hoàn hảo.",
                    shortDescription="Như một món quà dành cho người dùng, Macbook Air 13 inch 2014 được tung ra thị trường với một chút nâng cấp nhẹ nhàng phần cứng, tăng thời lượng pin và hấp dẫn nhất là giá cả đã được Apple “hạ nhiệt” đôi chút. Sản phẩm vẫn sở hữu thân hình đầy quyến rũ khi được giữ nguyên lớp vỏ nhôm nguyên khối, đường nét thiết kế chuyên nghiệp và tỉ mỉ đến hoàn hảo.",
                    imageSrc="macbook-air-MD760.jpg",
                    warrantyPeriod="16-09-09",
                    CPU=cpu.Single(g=>g.cpuID==1),
                    HardDrive=harddrive.Single(g=>g.hardDriveID==2),
                    Screen=screen.Single(g=>g.screenID==2),
                    Graphic=graphic.Single(g=>g.graphicID==2),
                    cd_DVD="DVD Super Multi Double Layer",
                    camera="HD Webcam, 0.9 MP", 
                    wifi="802.11b/g/n",     
                    os="Linux",
                    battery="Li-Ion-6 cell",
                    ram="DDR3L(1 khe RAM),4GB",   
                    unitPrice=24490000,
                    isNoLonger=false,
                    isNew=true,
                    isHot=false,
                    isSale=false,
                    quantity=10,
                    importPrice=11000000,
                    
                },
                new Product{ 
                    productID=8,
                    productName="Macbook Pro Retina MGXC2ZP/A",
                    productType="MACBOOK", 
                    Manufacturer=manufacturer.Single(g=>g.manufacturerID==5),
                    longDescription="Macbook Pro Retina MGXC2ZP/A chính là dòng máy tính cao cấp mới nhất thuộc dòng MacBook Pro Retina 15.4 inch của Apple, một trong những biểu tượng thời trang, đẳng cấp trong thế giới công nghệ trên toàn thế giới.",
                    shortDescription="Macbook Pro Retina MGXC2ZP/A chính là dòng máy tính cao cấp mới nhất thuộc dòng MacBook Pro Retina 15.4 inch của Apple, một trong những biểu tượng thời trang, đẳng cấp trong thế giới công nghệ trên toàn thế giới.",
                    imageSrc="macbook-pro-retina-mgxc2zp-a.jpg",
                    warrantyPeriod="16-09-09",
                    CPU=cpu.Single(g=>g.cpuID==1),
                    HardDrive=harddrive.Single(g=>g.hardDriveID==2),
                    Screen=screen.Single(g=>g.screenID==2),
                    Graphic=graphic.Single(g=>g.graphicID==2),
                    cd_DVD="DVD Super Multi Double Layer",
                    camera="HD Webcam, 0.9 MP", 
                    wifi="802.11b/g/n",     
                    os="Linux",
                    battery="Li-Ion-6 cell",
                    ram="DDR3L(1 khe RAM),4GB",   
                    unitPrice=59990000,
                    isNoLonger=false,
                    isNew=true,
                    isHot=true,
                    isSale=false,
                    quantity=10,
                    importPrice=11000000,
                   
                },
                new Product{ 
                    productID=9,
                    productName="Asus X453MA",
                    productType="ASUS", 
                    Manufacturer=manufacturer.Single(g=>g.manufacturerID==2),
                    longDescription="Vẫn giữ nét thiết kế rất đặc trưng, mặt lưng của Asus X453MA là những vân tròn đồng tâm theo phong cách Zenbook giúp máy sáng bóng, sang trọng hơn. Máy được vát mỏng về phía trước kết hợp với 4 góc bo tròn giúp thiết bị trong nhỏ gọn, thanh mảnh hơn thực tế.",
                    shortDescription="Vẫn giữ nét thiết kế rất đặc trưng, mặt lưng của Asus X453MA là những vân tròn đồng tâm theo phong cách Zenbook giúp máy sáng bóng, sang trọng hơn. Máy được vát mỏng về phía trước kết hợp với 4 góc bo tròn giúp thiết bị trong nhỏ gọn, thanh mảnh hơn thực tế.",
                    imageSrc="asus-x453ma.jpg",
                    warrantyPeriod="16-09-09",
                    CPU=cpu.Single(g=>g.cpuID==1),
                    HardDrive=harddrive.Single(g=>g.hardDriveID==2),
                    Screen=screen.Single(g=>g.screenID==2),
                    Graphic=graphic.Single(g=>g.graphicID==2),
                    cd_DVD="DVD Super Multi Double Layer",
                    camera="HD Webcam, 0.9 MP", 
                    wifi="802.11b/g/n",     
                    os="Linux",
                    battery="Li-Ion-6 cell",
                    ram="DDR3L(1 khe RAM),4GB",   
                    unitPrice=5990000,
                    isNoLonger=false,
                    isNew=true,
                    isHot=true,
                    isSale=false,
                    quantity=10,
                    importPrice=11000000,
                   
                },
                new Product{ 
                    productID=10,
                    productName="Asus-P550LD",
                    productType="ASUS", 
                    Manufacturer=manufacturer.Single(g=>g.manufacturerID==2),
                    longDescription="Sở hữu màn hình 15.6inch nhưng khá gọn nhẹ, đảm bảo tính di động của người dùng. Thiết kế sang trọng nhờ chất liệu cao cấp, chắc chắn, cấu hình khỏe sử dụng chip xử lý thế hệ thứ 4 của Intel và card đồ họa rời đầy mạnh mẽ của NVIDIA. Sản phẩm đáp ứng tốt nhu cầu đồ họa cũng như giải trí, đồng thời là sản phẩm thời trang giúp bạn thêm sang trọng, đẳng cấp.",
                    shortDescription="Sở hữu màn hình 15.6inch nhưng khá gọn nhẹ, đảm bảo tính di động của người dùng. Thiết kế sang trọng nhờ chất liệu cao cấp, chắc chắn, cấu hình khỏe sử dụng chip xử lý thế hệ thứ 4 của Intel và card đồ họa rời đầy mạnh mẽ của NVIDIA. Sản phẩm đáp ứng tốt nhu cầu đồ họa cũng như giải trí, đồng thời là sản phẩm thời trang giúp bạn thêm sang trọng, đẳng cấp.",
                    imageSrc="Asus-P550LD.jpg",
                    warrantyPeriod="16-09-09",
                    CPU=cpu.Single(g=>g.cpuID==1),
                    HardDrive=harddrive.Single(g=>g.hardDriveID==2),
                    Screen=screen.Single(g=>g.screenID==2),
                    Graphic=graphic.Single(g=>g.graphicID==2),
                    cd_DVD="DVD Super Multi Double Layer",
                    camera="HD Webcam, 0.9 MP", 
                    wifi="802.11b/g/n",     
                    os="Linux",
                    battery="Li-Ion-6 cell",
                    ram="DDR3L(1 khe RAM),4GB",   
                    unitPrice=15990000,
                    isNoLonger=false,
                    isNew=true,
                    isHot=false,
                    isSale=false,
                    quantity=10,
                    importPrice=11000000,
                    
                },
                new Product{ 
                    productID=11,
                    productName="ASUS P450LAV",
                    productType="ASUS", 
                    Manufacturer=manufacturer.Single(g=>g.manufacturerID==2),
                    longDescription="Chiếc laptop phù hợp để  phục vụ các công việc hàng ngày, các tác vụ văn phòng và chỉnh sửa hình ảnh thông thường. Hiệu năng của máy cao, cấu hình Core i5 mạnh mẽ giúp Asus P450LAV đáp ứng nhanh nhạy, phản hồi tức thời các tác vụ của người dùng. Hơn hết Asus dòng P là dòng máy đặc biệt dành cho doanh nhân, thiết kế sang trọng, thời lượng pin cao.",
                    shortDescription="Chiếc laptop phù hợp để  phục vụ các công việc hàng ngày, các tác vụ văn phòng và chỉnh sửa hình ảnh thông thường. Hiệu năng của máy cao, cấu hình Core i5 mạnh mẽ giúp Asus P450LAV đáp ứng nhanh nhạy, phản hồi tức thời các tác vụ của người dùng. Hơn hết Asus dòng P là dòng máy đặc biệt dành cho doanh nhân, thiết kế sang trọng, thời lượng pin cao.",
                    imageSrc="Asus-p450lav.jpg",
                    warrantyPeriod="16-09-09",
                    CPU=cpu.Single(g=>g.cpuID==1),
                    HardDrive=harddrive.Single(g=>g.hardDriveID==2),
                    Screen=screen.Single(g=>g.screenID==2),
                    Graphic=graphic.Single(g=>g.graphicID==2),
                    cd_DVD="DVD Super Multi Double Layer",
                    camera="HD Webcam, 0.9 MP", 
                    wifi="802.11b/g/n",     
                    os="Linux",
                    battery="Li-Ion-6 cell",
                    ram="DDR3L(1 khe RAM),4GB",   
                    unitPrice=12990000,
                    isNoLonger=false,
                    isNew=true,
                    isHot=true,
                    isSale=false,
                    quantity=10,
                    importPrice=11000000,
                    
                },
                new Product{ 
                    productID=12,
                    productName="ASUS-K551LA",
                    productType="ASUS", 
                    Manufacturer=manufacturer.Single(g=>g.manufacturerID==2),
                    longDescription="Sở hữu thiết kế thanh lịch và sang trọng của Asus cùng cấu hình Core i3 khỏe, hoạt động ổn định. Những tính năng hỗ trợ như công nghệ màn hình, âm thanh độc quyền giúp bạn thỏa mãn việc nghe – nhìn khi giải trí đa phương tiện. Sản phẩm thuộc dòng máy giá rẻ, phù hợp để giải quyết các công việc hàng ngày.",
                    shortDescription="Sở hữu thiết kế thanh lịch và sang trọng của Asus cùng cấu hình Core i3 khỏe, hoạt động ổn định. Những tính năng hỗ trợ như công nghệ màn hình, âm thanh độc quyền giúp bạn thỏa mãn việc nghe – nhìn khi giải trí đa phương tiện. Sản phẩm thuộc dòng máy giá rẻ, phù hợp để giải quyết các công việc hàng ngày.",
                    imageSrc="Asus-K551LA.jpg",
                    warrantyPeriod="16-09-09",
                    CPU=cpu.Single(g=>g.cpuID==2),
                    HardDrive=harddrive.Single(g=>g.hardDriveID==2),
                    Screen=screen.Single(g=>g.screenID==3),
                    Graphic=graphic.Single(g=>g.graphicID==1),
                    cd_DVD="DVD Super Multi Double Layer",
                    camera="HD Webcam, 0.9 MP", 
                    wifi="802.11b/g/n",     
                    os="Linux",
                    battery="Li-Ion 4 cell",
                    ram="DDR3L(1 khe RAM),4GB",   
                    unitPrice=12190000,
                    isNoLonger=false,
                    isNew=false,
                    isHot=true,
                    isSale=false,
                    quantity=10,
                    importPrice=11000000,
                      
                }
                
            };
            products.ForEach(s => context.Products.Add(s));
            context.SaveChanges();

            //Images
            var images = new List<Image>
            {
                new Image
                {
                    imageID="1",
                    imageName="DELL Inspiron 3542 Detail 1",
                    product=products.Single(g=>g.productID==1),
                    src="dell-inspiron-3542-detail1.jpg"
                },
                new Image
                {
                    imageID="2",
                    imageName="DELL Inspiron 3542 Detail 2",
                    product=products.Single(g=>g.productID==1),
                    src="dell-inspiron-3542-detail2.jpg"
                },
                new Image
                {
                    imageID="3",
                    imageName="DELL Inspiron 3542 Detail 3",
                    product=products.Single(g=>g.productID==1),
                    src="dell-inspiron-3542-detail3.jpg"
                }
            };
            images.ForEach(s => context.Images.Add(s));
            context.SaveChanges();

            //Province
            var provinces = new List<Province>
            {
                new Province
                {
                    provinceID=1,
                    provinceName="Bà Rịa-Vũng Tàu"
                },
                new Province
                {
                    provinceID=2,
                    provinceName="Đồng Nai"
                }
            };
            provinces.ForEach(s => context.Provinces.Add(s));
            context.SaveChanges();

            //District
            var districts = new List<District>
            {
                new District
                {
                    districtID=1,
                    districtName="Tân Thành-Phú Mỹ",
                    Province=provinces.Single(g=>g.provinceID==1)
                },
                new District
                {
                    districtID=2,
                    districtName="Xuyên Lộc-Phước Bửu",
                    Province=provinces.Single(g=>g.provinceID==1)
                },
                new District
                {
                    districtID=3,
                    districtName="Côn Đảo",
                    Province=provinces.Single(g=>g.provinceID==1)
                },
                new District
                {
                    districtID=4,
                    districtName="Long Thành",
                    Province=provinces.Single(g=>g.provinceID==2)
                },
                new District
                {
                    districtID=5,
                    districtName="Nhơn Trạch",
                    Province=provinces.Single(g=>g.provinceID==2)
                },
                new District
                {
                    districtID=6,
                    districtName="Vĩnh Cửu",
                    Province=provinces.Single(g=>g.provinceID==2)
                }
            };
            districts.ForEach(s => context.Districts.Add(s));
            context.SaveChanges();
        }
    }
}