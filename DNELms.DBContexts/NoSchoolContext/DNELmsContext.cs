using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace DNELms.DBContexts.NoSchoolContext
{
    public partial class NoSchoolContext : DbContext
    {
        public NoSchoolContext()
        {
        }

        public NoSchoolContext(DbContextOptions<NoSchoolContext> options)
            : base(options)
        {
        }

        public virtual DbSet<ActivityLog> ActivityLogs { get; set; }
        public virtual DbSet<AspNetRole> AspNetRoles { get; set; }
        public virtual DbSet<AspNetRoleClaim> AspNetRoleClaims { get; set; }
        public virtual DbSet<AspNetUser> AspNetUsers { get; set; }
        public virtual DbSet<AspNetUserClaim> AspNetUserClaims { get; set; }
        public virtual DbSet<AspNetUserLogin> AspNetUserLogins { get; set; }
        public virtual DbSet<AspNetUserRole> AspNetUserRoles { get; set; }
        public virtual DbSet<AspNetUserToken> AspNetUserTokens { get; set; }
        public virtual DbSet<Banner> Banners { get; set; }
        public virtual DbSet<City> Cities { get; set; }
        public virtual DbSet<Country> Countries { get; set; }
        public virtual DbSet<Course> Courses { get; set; }
        public virtual DbSet<CourseAssignment> CourseAssignments { get; set; }
        public virtual DbSet<CourseCategory> CourseCategories { get; set; }
        public virtual DbSet<CourseInstructor> CourseInstructors { get; set; }
        public virtual DbSet<CourseLessonsDetail> CourseLessonsDetails { get; set; }
        public virtual DbSet<CourseLessonsMaster> CourseLessonsMasters { get; set; }
        public virtual DbSet<CourseLevel> CourseLevels { get; set; }
        public virtual DbSet<CourseOrderPaymentDetail> CourseOrderPaymentDetails { get; set; }
        public virtual DbSet<CourseOrdersDetail> CourseOrdersDetails { get; set; }
        public virtual DbSet<CourseOrdersMaster> CourseOrdersMasters { get; set; }
        public virtual DbSet<CourseQuizzsMaster> CourseQuizzsMasters { get; set; }
        public virtual DbSet<CourseRating> CourseRatings { get; set; }
        public virtual DbSet<CourseType> CourseTypes { get; set; }
        public virtual DbSet<DeviceCode> DeviceCodes { get; set; }
        public virtual DbSet<EmailProvider> EmailProviders { get; set; }
        public virtual DbSet<EmailSmstemplate> EmailSmstemplates { get; set; }
        public virtual DbSet<ErrorLog> ErrorLogs { get; set; }
        public virtual DbSet<ExternalAuthentication> ExternalAuthentications { get; set; }
        public virtual DbSet<Language> Languages { get; set; }
        public virtual DbSet<Message> Messages { get; set; }
        public virtual DbSet<PersistedGrant> PersistedGrants { get; set; }
        public virtual DbSet<QueueEmail> QueueEmails { get; set; }
        public virtual DbSet<QuizQuestionDetail> QuizQuestionDetails { get; set; }
        public virtual DbSet<QuizQuestionsMaster> QuizQuestionsMasters { get; set; }
        public virtual DbSet<State> States { get; set; }
        public virtual DbSet<StudentAttemptedQuizz> StudentAttemptedQuizzs { get; set; }
        public virtual DbSet<StudentEnrolledCourse> StudentEnrolledCourses { get; set; }
        public virtual DbSet<StudentEnrolledCoursesPayment> StudentEnrolledCoursesPayments { get; set; }
        public virtual DbSet<StudentSubmitedAssignment> StudentSubmitedAssignments { get; set; }
        public virtual DbSet<UserCart> UserCarts { get; set; }
        public virtual DbSet<UserWishlist> UserWishlists { get; set; }
        public virtual DbSet<WebSetting> WebSettings { get; set; }
        public virtual DbSet<CourseRequirements> CourseRequirements { get; set; }
        public virtual DbSet<CourseOvercomes> CourseOvercomes { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=.\\MYSQL;Database=DNELms;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<ActivityLog>(entity =>
            {
                entity.ToTable("ActivityLog");

                entity.Property(e => e.Action).HasMaxLength(3000);

                entity.Property(e => e.CreatedBy)
                    .IsRequired()
                    .HasMaxLength(450);

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.TableName).HasMaxLength(500);

                entity.HasOne(d => d.CreatedByNavigation)
                    .WithMany(p => p.ActivityLogs)
                    .HasForeignKey(d => d.CreatedBy)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ActivityLog_AspNetUsers");
            });

            modelBuilder.Entity<AspNetRole>(entity =>
            {
                entity.Property(e => e.Name).HasMaxLength(256);

                entity.Property(e => e.NormalizedName).HasMaxLength(256);
            });

            modelBuilder.Entity<AspNetRoleClaim>(entity =>
            {
                entity.Property(e => e.RoleId)
                    .IsRequired()
                    .HasMaxLength(450);

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.AspNetRoleClaims)
                    .HasForeignKey(d => d.RoleId);
            });

            modelBuilder.Entity<AspNetUser>(entity =>
            {
                entity.Property(e => e.Address).HasMaxLength(500);

                entity.Property(e => e.Email).HasMaxLength(256);

                entity.Property(e => e.FirstName).HasMaxLength(150);

                entity.Property(e => e.FlatPassword).HasMaxLength(150);

                entity.Property(e => e.IsActive)
                    .IsRequired()
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.LastName).HasMaxLength(150);

                entity.Property(e => e.NormalizedEmail).HasMaxLength(256);

                entity.Property(e => e.NormalizedUserName).HasMaxLength(256);

                entity.Property(e => e.UserName).HasMaxLength(256);

                entity.HasOne(d => d.City)
                    .WithMany(p => p.AspNetUsers)
                    .HasForeignKey(d => d.CityId)
                    .HasConstraintName("FK_AspNetUsers_cities");

                entity.HasOne(d => d.Country)
                    .WithMany(p => p.AspNetUsers)
                    .HasForeignKey(d => d.CountryId)
                    .HasConstraintName("FK_AspNetUsers_Countries");

                entity.HasOne(d => d.State)
                    .WithMany(p => p.AspNetUsers)
                    .HasForeignKey(d => d.StateId)
                    .HasConstraintName("FK_AspNetUsers_States");
            });

            modelBuilder.Entity<AspNetUserClaim>(entity =>
            {
                entity.Property(e => e.UserId)
                    .IsRequired()
                    .HasMaxLength(450);

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AspNetUserClaims)
                    .HasForeignKey(d => d.UserId);
            });

            modelBuilder.Entity<AspNetUserLogin>(entity =>
            {
                entity.HasKey(e => new { e.LoginProvider, e.ProviderKey });

                entity.Property(e => e.LoginProvider).HasMaxLength(128);

                entity.Property(e => e.ProviderKey).HasMaxLength(128);

                entity.Property(e => e.UserId)
                    .IsRequired()
                    .HasMaxLength(450);

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AspNetUserLogins)
                    .HasForeignKey(d => d.UserId);
            });

            modelBuilder.Entity<AspNetUserRole>(entity =>
            {
                entity.HasKey(e => new { e.UserId, e.RoleId });

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.AspNetUserRoles)
                    .HasForeignKey(d => d.RoleId);

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AspNetUserRoles)
                    .HasForeignKey(d => d.UserId);
            });

            modelBuilder.Entity<AspNetUserToken>(entity =>
            {
                entity.HasKey(e => new { e.UserId, e.LoginProvider, e.Name });

                entity.Property(e => e.LoginProvider).HasMaxLength(128);

                entity.Property(e => e.Name).HasMaxLength(128);

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AspNetUserTokens)
                    .HasForeignKey(d => d.UserId);
            });

            modelBuilder.Entity<Banner>(entity =>
            {
                entity.Property(e => e.BannerDesc).HasMaxLength(500);

                entity.Property(e => e.BannerTitle).HasMaxLength(250);

                entity.Property(e => e.ImagePath).HasMaxLength(500);

                entity.Property(e => e.IsActive)
                    .IsRequired()
                    .HasDefaultValueSql("((1))");
            });

            modelBuilder.Entity<City>(entity =>
            {
                entity.Property(e => e.CountryCode)
                    .IsRequired()
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.CreatedDate)
                    .HasPrecision(0)
                    .HasDefaultValueSql("('2014-01-01 01:01:01')");

                entity.Property(e => e.Flag).HasDefaultValueSql("('1')");

                entity.Property(e => e.Latitude).HasColumnType("decimal(10, 8)");

                entity.Property(e => e.Longitude).HasColumnType("decimal(11, 8)");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(255);

                entity.Property(e => e.StateCode)
                    .IsRequired()
                    .HasMaxLength(255);

                entity.Property(e => e.UpdatedDate)
                    .HasPrecision(0)
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.WikiDataId).HasMaxLength(255);

                entity.HasOne(d => d.Country)
                    .WithMany(p => p.Cities)
                    .HasForeignKey(d => d.CountryId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Cities_Countries");

                entity.HasOne(d => d.State)
                    .WithMany(p => p.Cities)
                    .HasForeignKey(d => d.StateId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Cities_States");
            });

            modelBuilder.Entity<Country>(entity =>
            {
                entity.Property(e => e.Capital).HasMaxLength(255);

                entity.Property(e => e.Currency).HasMaxLength(255);

                entity.Property(e => e.CurrencySymbol).HasMaxLength(255);

                entity.Property(e => e.Emoji).HasMaxLength(191);

                entity.Property(e => e.EmojiU).HasMaxLength(191);

                entity.Property(e => e.Flag).HasDefaultValueSql("('1')");

                entity.Property(e => e.Iso2).HasMaxLength(2);

                entity.Property(e => e.Iso3).HasMaxLength(3);

                entity.Property(e => e.Latitude).HasColumnType("decimal(10, 8)");

                entity.Property(e => e.Longitude).HasColumnType("decimal(11, 8)");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.Native).HasMaxLength(255);

                entity.Property(e => e.PhoneCode).HasMaxLength(255);

                entity.Property(e => e.Region).HasMaxLength(255);

                entity.Property(e => e.Subregion).HasMaxLength(255);

                entity.Property(e => e.Tld).HasMaxLength(255);

                entity.Property(e => e.UpdatedDate).HasDefaultValueSql("(getdate())");

                entity.Property(e => e.WikiDataId).HasMaxLength(255);
            });

            modelBuilder.Entity<Course>(entity =>
            {
                entity.Property(e => e.CourseCode).HasMaxLength(100);

                entity.Property(e => e.CourseLevelId).HasComment("Level May be Beginner , Advance or Intermediate");

                entity.Property(e => e.CourseTypeId).HasComment("Type may be Free or Paid");

                entity.Property(e => e.CreatedBy).HasMaxLength(450);

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.DiscountPercentage).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.DiscountPrice).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.EndDate).HasColumnType("datetime");

                entity.Property(e => e.InstructorId).HasMaxLength(450);

                entity.Property(e => e.IsActive)
                    .IsRequired()
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.LargeImagePath)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.MetaKeyword).HasMaxLength(500);

                entity.Property(e => e.MetaTitle).HasMaxLength(250);

                entity.Property(e => e.Name).HasMaxLength(250);

                entity.Property(e => e.Price).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.PublishDate).HasColumnType("datetime");

                entity.Property(e => e.SeUrl).HasMaxLength(500);

                entity.Property(e => e.ShowOnHome)
                    .IsRequired()
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.ShowOnSitemap)
                    .IsRequired()
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.SmallImagePath).HasMaxLength(100);

                entity.Property(e => e.StartDate).HasColumnType("datetime");

                entity.Property(e => e.Status)
                    .HasMaxLength(50)
                    .HasComment("Published, UnPublished, Draft, Archive");

                entity.Property(e => e.UnPublishDate).HasColumnType("datetime");

                entity.Property(e => e.UpdatedBy).HasMaxLength(450);

                entity.Property(e => e.UpdatedDate).HasColumnType("datetime");

                entity.Property(e => e.Visibility)
                    .HasMaxLength(100)
                    .HasComment("To All vistors, Only to Registered Students, Only to Students you registered");

                entity.HasOne(d => d.CourseCategory)
                    .WithMany(p => p.Courses)
                    .HasForeignKey(d => d.CourseCategoryId)
                    .HasConstraintName("FK_Courses_CourseCategory");

                entity.HasOne(d => d.CourseLevel)
                    .WithMany(p => p.Courses)
                    .HasForeignKey(d => d.CourseLevelId)
                    .HasConstraintName("FK_Courses_CourseLevels");

                entity.HasOne(d => d.CourseType)
                    .WithMany(p => p.Courses)
                    .HasForeignKey(d => d.CourseTypeId)
                    .HasConstraintName("FK_Courses_CourseTypes");

                entity.HasOne(d => d.Instructor)
                    .WithMany(p => p.Courses)
                    .HasForeignKey(d => d.InstructorId)
                    .HasConstraintName("FK_Courses_AspNetUsers");

                entity.HasOne(d => d.Language)
                    .WithMany(p => p.Courses)
                    .HasForeignKey(d => d.LanguageId)
                    .HasConstraintName("FK_Courses_Languages");

                entity.HasOne(d => d.Parent)
                    .WithMany(p => p.InverseParent)
                    .HasForeignKey(d => d.ParentId)
                    .HasConstraintName("FK_Courses_Courses1");
            });

            modelBuilder.Entity<CourseOvercomes>(e =>
            {
                
            });
            
            modelBuilder.Entity<CourseRequirements>(e =>
            {
                
            });

            modelBuilder.Entity<CourseAssignment>(entity =>
            {
                entity.Property(e => e.AllowModify).HasDefaultValueSql("((1))");

                entity.Property(e => e.AssignmentEndDate).HasColumnType("datetime");

                entity.Property(e => e.AssignmentStartDate).HasColumnType("datetime");

                entity.Property(e => e.CreatedBy).HasMaxLength(450);

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.FilePath).HasMaxLength(20);

                entity.Property(e => e.UpdatedBy).HasMaxLength(450);

                entity.Property(e => e.UpdatedDate).HasColumnType("datetime");

                entity.HasOne(d => d.Course)
                    .WithMany(p => p.CourseAssignments)
                    .HasForeignKey(d => d.CourseId)
                    .HasConstraintName("FK_CourseAssignments_Courses");
            });

            modelBuilder.Entity<CourseCategory>(entity =>
            {
                entity.ToTable("CourseCategory");

                entity.Property(e => e.CreatedBy).HasMaxLength(450);

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.IsActive).HasDefaultValueSql("((0))");

                entity.Property(e => e.Name).HasMaxLength(250);

                entity.Property(e => e.UpdatedBy).HasMaxLength(450);

                entity.Property(e => e.UpdatedDate).HasColumnType("datetime");

                entity.HasOne(d => d.Parent)
                    .WithMany(p => p.InverseParent)
                    .HasForeignKey(d => d.ParentId)
                    .HasConstraintName("FK_CourseCategory_CourseCategory");
            });

            modelBuilder.Entity<CourseInstructor>(entity =>
            {
                entity.ToTable("CourseInstructor");

                entity.Property(e => e.InstructorId).HasMaxLength(450);

                entity.HasOne(d => d.Course)
                    .WithMany(p => p.CourseInstructors)
                    .HasForeignKey(d => d.CourseId)
                    .HasConstraintName("FK_CourseInstructor_Courses");

                entity.HasOne(d => d.Instructor)
                    .WithMany(p => p.CourseInstructors)
                    .HasForeignKey(d => d.InstructorId)
                    .HasConstraintName("FK_CourseInstructor_AspNetUsers");
            });

            modelBuilder.Entity<CourseLessonsDetail>(entity =>
            {
                entity.ToTable("CourseLessonsDetail");

                entity.Property(e => e.Accessiblity)
                    .HasMaxLength(100)
                    .HasComment("To all visitors, only registerd students, only students you registerd");

                entity.Property(e => e.ContentType)
                    .HasMaxLength(10)
                    .HasComment("File or Video");

                entity.Property(e => e.FilePath).HasMaxLength(50);

                entity.HasOne(d => d.CourseLesson)
                    .WithMany(p => p.CourseLessonsDetails)
                    .HasForeignKey(d => d.CourseLessonId)
                    .HasConstraintName("FK_CourseLessonsDetail_CourseLessonsMaster");
            });

            modelBuilder.Entity<CourseLessonsMaster>(entity =>
            {
                entity.ToTable("CourseLessonsMaster");

                entity.Property(e => e.CreatedBy).HasMaxLength(450);

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.Name).HasMaxLength(500);

                entity.Property(e => e.UpdatedBy).HasMaxLength(450);

                entity.Property(e => e.UpdatedDate).HasColumnType("datetime");

                entity.HasOne(d => d.Course)
                    .WithMany(p => p.CourseLessonsMasters)
                    .HasForeignKey(d => d.CourseId)
                    .HasConstraintName("FK_CourseLessonsMaster_Courses");
            });

            modelBuilder.Entity<CourseLevel>(entity =>
            {
                entity.Property(e => e.CreatedBy).HasMaxLength(450);

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.IsActive)
                    .IsRequired()
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.Name).HasMaxLength(250);

                entity.Property(e => e.UpdatedBy).HasMaxLength(450);

                entity.Property(e => e.UpdatedDate).HasColumnType("datetime");
            });

            modelBuilder.Entity<CourseOrderPaymentDetail>(entity =>
            {
                entity.ToTable("CourseOrderPaymentDetail");

                entity.Property(e => e.CreatedBy).HasMaxLength(450);

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.FilePath).HasMaxLength(500);

                entity.Property(e => e.FinalAmount).HasColumnType("decimal(18, 1)");

                entity.Property(e => e.PayeeId).HasMaxLength(50);

                entity.Property(e => e.PaymentAmount).HasColumnType("decimal(18, 0)");

                entity.Property(e => e.PaymentStatus).HasMaxLength(50);

                entity.Property(e => e.PaymentType).HasMaxLength(50);

                entity.Property(e => e.UpdatedBy).HasMaxLength(450);

                entity.Property(e => e.UpdatedDate).HasColumnType("datetime");

                entity.Property(e => e.UserId).HasMaxLength(450);

                entity.HasOne(d => d.CourseOrder)
                    .WithMany(p => p.CourseOrderPaymentDetails)
                    .HasForeignKey(d => d.CourseOrderId)
                    .HasConstraintName("FK_CourseOrderPaymentDetail_CourseOrdersMaster");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.CourseOrderPaymentDetails)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK_CourseOrderPaymentDetail_AspNetUsers");
            });

            modelBuilder.Entity<CourseOrdersDetail>(entity =>
            {
                entity.ToTable("CourseOrdersDetail");

                entity.HasOne(d => d.Course)
                    .WithMany(p => p.CourseOrdersDetails)
                    .HasForeignKey(d => d.CourseId)
                    .HasConstraintName("FK_CourseOrdersDetail_Courses");

                entity.HasOne(d => d.CourseOrder)
                    .WithMany(p => p.CourseOrdersDetails)
                    .HasForeignKey(d => d.CourseOrderId)
                    .HasConstraintName("FK_CourseOrdersDetail_CourseOrdersMaster");
            });

            modelBuilder.Entity<CourseOrdersMaster>(entity =>
            {
                entity.ToTable("CourseOrdersMaster");

                entity.Property(e => e.CreatedBy).HasMaxLength(450);

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.Status).HasMaxLength(50);

                entity.Property(e => e.UpdatedBy).HasMaxLength(450);

                entity.Property(e => e.UpdatedDate).HasColumnType("datetime");

                entity.Property(e => e.UserId).HasMaxLength(450);

                entity.HasOne(d => d.User)
                    .WithMany(p => p.CourseOrdersMasters)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK_CourseOrdersMaster_AspNetUsers");
            });

            modelBuilder.Entity<CourseQuizzsMaster>(entity =>
            {
                entity.ToTable("CourseQuizzsMaster");

                entity.Property(e => e.AllowedReview)
                    .IsRequired()
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.CreatedBy).HasMaxLength(450);

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.QuizDate).HasColumnType("date");

                entity.Property(e => e.UpdatedBy).HasMaxLength(450);

                entity.Property(e => e.UpdatedDate).HasColumnType("datetime");

                entity.HasOne(d => d.Course)
                    .WithMany(p => p.CourseQuizzsMasters)
                    .HasForeignKey(d => d.CourseId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_CourseQuizzsMaster_Courses");
            });

            modelBuilder.Entity<CourseRating>(entity =>
            {
                entity.Property(e => e.UserId).HasMaxLength(450);

                entity.HasOne(d => d.Course)
                    .WithMany(p => p.CourseRatings)
                    .HasForeignKey(d => d.CourseId)
                    .HasConstraintName("FK_CourseRatings_Courses");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.CourseRatings)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK_CourseRatings_AspNetUsers");
            });

            modelBuilder.Entity<CourseType>(entity =>
            {
                entity.Property(e => e.CreatedBy).HasMaxLength(450);

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.Name).HasMaxLength(250);

                entity.Property(e => e.UpdatedBy).HasMaxLength(450);

                entity.Property(e => e.UpdatedDate).HasColumnType("datetime");
            });

            modelBuilder.Entity<DeviceCode>(entity =>
            {
                entity.HasKey(e => e.UserCode);

                entity.Property(e => e.UserCode).HasMaxLength(200);

                entity.Property(e => e.ClientId)
                    .IsRequired()
                    .HasMaxLength(200);

                entity.Property(e => e.Data).IsRequired();

                entity.Property(e => e.Description).HasMaxLength(200);

                entity.Property(e => e.DeviceCode1)
                    .IsRequired()
                    .HasMaxLength(200)
                    .HasColumnName("DeviceCode");

                entity.Property(e => e.SessionId).HasMaxLength(100);

                entity.Property(e => e.SubjectId).HasMaxLength(200);
            });

            modelBuilder.Entity<EmailProvider>(entity =>
            {
                entity.Property(e => e.Email).HasMaxLength(250);

                entity.Property(e => e.FromDisplayName).HasMaxLength(250);

                entity.Property(e => e.FromPassword).HasMaxLength(250);

                entity.Property(e => e.Smtpport).HasColumnName("SMTPPort");

                entity.Property(e => e.Smtpssl).HasColumnName("SMTPSsl");

                entity.Property(e => e.Smtpurl)
                    .HasMaxLength(500)
                    .HasColumnName("SMTPurl");
            });

            modelBuilder.Entity<EmailSmstemplate>(entity =>
            {
                entity.ToTable("EmailSMSTemplate");

                entity.Property(e => e.Bcc)
                    .HasMaxLength(500)
                    .HasColumnName("BCC");

                entity.Property(e => e.Cc)
                    .HasMaxLength(500)
                    .HasColumnName("CC");

                entity.Property(e => e.CreatedBy)
                    .IsRequired()
                    .HasMaxLength(450);

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.IsActive)
                    .IsRequired()
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.Name).HasMaxLength(50);

                entity.Property(e => e.Subject).HasMaxLength(1500);

                entity.Property(e => e.Type)
                    .IsRequired()
                    .HasMaxLength(5);

                entity.Property(e => e.UpdatedBy).HasMaxLength(450);

                entity.Property(e => e.UpdatedDate).HasColumnType("datetime");
            });

            modelBuilder.Entity<ErrorLog>(entity =>
            {
                entity.ToTable("ErrorLog");

                entity.Property(e => e.CreateDate).HasColumnType("datetime");

                entity.Property(e => e.IpAddress).HasMaxLength(50);

                entity.Property(e => e.Message)
                    .IsRequired()
                    .HasMaxLength(2000);

                entity.Property(e => e.Url)
                    .IsRequired()
                    .HasMaxLength(250);

                entity.Property(e => e.UserId)
                    .HasMaxLength(450)
                    .HasColumnName("User_Id");
            });

            modelBuilder.Entity<ExternalAuthentication>(entity =>
            {
                entity.ToTable("ExternalAuthentication");

                entity.Property(e => e.FacebookAppId).HasMaxLength(250);

                entity.Property(e => e.FacebookAuthKey).HasMaxLength(250);

                entity.Property(e => e.GoogleKey).HasMaxLength(250);

                entity.Property(e => e.GoogleSecret).HasMaxLength(250);

                entity.Property(e => e.UpdatedDate).HasColumnType("datetime");
            });

            modelBuilder.Entity<Language>(entity =>
            {
                entity.Property(e => e.CreatedBy).HasMaxLength(450);

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.IsActive)
                    .IsRequired()
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.Name).HasMaxLength(20);

                entity.Property(e => e.ShortName)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.ShortNameLocal).HasMaxLength(20);

                entity.Property(e => e.UpdatedBy).HasMaxLength(450);

                entity.Property(e => e.UpdatedDate).HasColumnType("datetime");
            });

            modelBuilder.Entity<Message>(entity =>
            {
                entity.Property(e => e.CreatedDt)
                    .HasColumnType("datetime")
                    .HasColumnName("CreatedDT");

                entity.Property(e => e.IpAddress).HasMaxLength(50);

                entity.Property(e => e.Message1).HasColumnName("Message");

                entity.Property(e => e.Mfrom)
                    .HasMaxLength(450)
                    .HasColumnName("MFrom");

                entity.Property(e => e.Mto)
                    .HasMaxLength(450)
                    .HasColumnName("MTo");
            });

            modelBuilder.Entity<PersistedGrant>(entity =>
            {
                entity.HasKey(e => e.Key);

                entity.Property(e => e.Key).HasMaxLength(200);

                entity.Property(e => e.ClientId)
                    .IsRequired()
                    .HasMaxLength(200);

                entity.Property(e => e.Data).IsRequired();

                entity.Property(e => e.Description).HasMaxLength(200);

                entity.Property(e => e.SessionId).HasMaxLength(100);

                entity.Property(e => e.SubjectId).HasMaxLength(200);

                entity.Property(e => e.Type)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<QueueEmail>(entity =>
            {
                entity.Property(e => e.MailToDisplayName).HasMaxLength(50);

                entity.Property(e => e.MailToEmail).HasMaxLength(250);

                entity.HasOne(d => d.EmailProvider)
                    .WithMany(p => p.QueueEmails)
                    .HasForeignKey(d => d.EmailProviderId)
                    .HasConstraintName("FK_QueueEmails_EmailProviders");

                entity.HasOne(d => d.EmailTemplate)
                    .WithMany(p => p.QueueEmails)
                    .HasForeignKey(d => d.EmailTemplateId)
                    .HasConstraintName("FK_QueueEmails_QueueEmails");
            });

            modelBuilder.Entity<QuizQuestionDetail>(entity =>
            {
                entity.ToTable("QuizQuestionDetail");

                entity.Property(e => e.Qoption)
                    .HasMaxLength(250)
                    .HasColumnName("QOption");

                entity.Property(e => e.Type)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength(true)
                    .HasComment("Type May be A , B, C ,D");

                entity.HasOne(d => d.Question)
                    .WithMany(p => p.QuizQuestionDetails)
                    .HasForeignKey(d => d.QuestionId)
                    .HasConstraintName("FK_QuizQuestionDetail_QuizQuestionsMaster");
            });

            modelBuilder.Entity<QuizQuestionsMaster>(entity =>
            {
                entity.ToTable("QuizQuestionsMaster");

                entity.Property(e => e.Question).HasMaxLength(500);

                entity.Property(e => e.QuestionType).HasMaxLength(50);

                entity.HasOne(d => d.Quiz)
                    .WithMany(p => p.QuizQuestionsMasters)
                    .HasForeignKey(d => d.QuizId)
                    .HasConstraintName("FK_QuizQuestionsMaster_CourseQuizzsMaster");
            });

            modelBuilder.Entity<State>(entity =>
            {
                entity.Property(e => e.CountryCode)
                    .IsRequired()
                    .HasMaxLength(2);

                entity.Property(e => e.CreatedDate).HasPrecision(0);

                entity.Property(e => e.FipsCode).HasMaxLength(255);

                entity.Property(e => e.Flag).HasDefaultValueSql("('1')");

                entity.Property(e => e.Iso2).HasMaxLength(255);

                entity.Property(e => e.Latitude).HasColumnType("decimal(10, 8)");

                entity.Property(e => e.Longitude).HasColumnType("decimal(11, 8)");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(255);

                entity.Property(e => e.UpdatedDate)
                    .HasPrecision(0)
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.WikiDataId).HasMaxLength(255);

                entity.HasOne(d => d.Country)
                    .WithMany(p => p.States)
                    .HasForeignKey(d => d.CountryId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_States_Countries");
            });

            modelBuilder.Entity<StudentAttemptedQuizz>(entity =>
            {
                entity.Property(e => e.QuizAttemptedDate).HasColumnType("datetime");

                entity.Property(e => e.StudentAnswerType)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.StudentId).HasMaxLength(450);

                entity.HasOne(d => d.Question)
                    .WithMany(p => p.StudentAttemptedQuizzs)
                    .HasForeignKey(d => d.QuestionId)
                    .HasConstraintName("FK_StudentAttemptedQuizzs_QuizQuestionsMaster");

                entity.HasOne(d => d.Quiz)
                    .WithMany(p => p.StudentAttemptedQuizzs)
                    .HasForeignKey(d => d.QuizId)
                    .HasConstraintName("FK_StudentAttemptedQuizzs_CourseQuizzsMaster");

                entity.HasOne(d => d.Student)
                    .WithMany(p => p.StudentAttemptedQuizzs)
                    .HasForeignKey(d => d.StudentId)
                    .HasConstraintName("FK_StudentAttemptedQuizzs_AspNetUsers");
            });

            modelBuilder.Entity<StudentEnrolledCourse>(entity =>
            {
                entity.Property(e => e.DiscountPrice).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.EnrolledDate).HasColumnType("datetime");

                entity.Property(e => e.Price).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.StudentId).HasMaxLength(450);

                entity.HasOne(d => d.Course)
                    .WithMany(p => p.StudentEnrolledCourses)
                    .HasForeignKey(d => d.CourseId)
                    .HasConstraintName("FK_StudentEnrolledCourses_Courses");

                entity.HasOne(d => d.Student)
                    .WithMany(p => p.StudentEnrolledCourses)
                    .HasForeignKey(d => d.StudentId)
                    .HasConstraintName("FK_StudentEnrolledCourses_AspNetUsers");
            });

            modelBuilder.Entity<StudentEnrolledCoursesPayment>(entity =>
            {
                entity.ToTable("StudentEnrolledCoursesPayment");

                entity.Property(e => e.Amount).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.PayerId).HasMaxLength(50);

                entity.Property(e => e.PaymentEvidencePicture).HasMaxLength(20);

                entity.Property(e => e.PaymentType).HasMaxLength(20);

                entity.Property(e => e.Status).HasMaxLength(20);

                entity.Property(e => e.TransactionDate).HasColumnType("datetime");

                entity.Property(e => e.TransactionId).HasMaxLength(100);

                entity.HasOne(d => d.EnrolledCourse)
                    .WithMany(p => p.StudentEnrolledCoursesPayments)
                    .HasForeignKey(d => d.EnrolledCourseId)
                    .HasConstraintName("FK_StudentEnrolledCoursesPayment_StudentEnrolledCourses");
            });

            modelBuilder.Entity<StudentSubmitedAssignment>(entity =>
            {
                entity.ToTable("StudentSubmitedAssignment");

                entity.Property(e => e.ModifiedDate).HasColumnType("datetime");

                entity.Property(e => e.StudentId).HasMaxLength(450);

                entity.Property(e => e.SubmissionDate).HasColumnType("datetime");

                entity.Property(e => e.SubmittedFilePath).HasMaxLength(20);

                entity.HasOne(d => d.Assignment)
                    .WithMany(p => p.StudentSubmitedAssignments)
                    .HasForeignKey(d => d.AssignmentId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_StudentSubmitedAssignment_CourseAssignments");

                entity.HasOne(d => d.Student)
                    .WithMany(p => p.StudentSubmitedAssignments)
                    .HasForeignKey(d => d.StudentId)
                    .HasConstraintName("FK_StudentSubmitedAssignment_AspNetUsers");
            });

            modelBuilder.Entity<UserCart>(entity =>
            {
                entity.ToTable("UserCart");

                entity.Property(e => e.CreatedBy).HasMaxLength(450);

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.UpdatedBy).HasMaxLength(450);

                entity.Property(e => e.UpdatedDate).HasColumnType("datetime");

                entity.HasOne(d => d.Course)
                    .WithMany(p => p.UserCarts)
                    .HasForeignKey(d => d.CourseId)
                    .HasConstraintName("FK_UserCart_Courses");

                entity.HasOne(d => d.CreatedByNavigation)
                    .WithMany(p => p.UserCarts)
                    .HasForeignKey(d => d.CreatedBy)
                    .HasConstraintName("FK_UserCart_AspNetUsers");
            });

            modelBuilder.Entity<UserWishlist>(entity =>
            {
                entity.ToTable("UserWishlist");

                entity.Property(e => e.CreatedBy).HasMaxLength(450);

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.HasOne(d => d.Course)
                    .WithMany(p => p.UserWishlists)
                    .HasForeignKey(d => d.CourseId)
                    .HasConstraintName("FK_UserWishlist_Courses");

                entity.HasOne(d => d.CreatedByNavigation)
                    .WithMany(p => p.UserWishlists)
                    .HasForeignKey(d => d.CreatedBy)
                    .HasConstraintName("FK_UserWishlist_UserWishlist");
            });

            modelBuilder.Entity<WebSetting>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedOnAdd();

                entity.Property(e => e.PhoneNo).HasMaxLength(20);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
