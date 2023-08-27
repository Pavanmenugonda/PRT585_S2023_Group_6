using Microsoft.EntityFrameworkCore;
using DAL.Entities;
using System;

namespace DAL.DataContext
{
    public class DatabaseContext : DbContext
    {
        public class OptionsBuild
        {
            //CONSTRUCTOR
            public OptionsBuild()
            {
                //AppConfiguration class with our connection string.
                Settings = new AppConfiguration();
                //Inits a class which allows us to configure the database connection for a db context.
                //In our case allocate the connection string that our DatabaseContext(Db Sessions) will use.
                OptionsBuilder = new DbContextOptionsBuilder<DatabaseContext>();
                //Allocates the connection string to be used when connecting to a Microsoft Sql Database
                OptionsBuilder.UseSqlServer(Settings.SqlConnectionString);
                //Allocates the set options to be used by the DbContext [Eg our connection string it must use when DatabaseContext it is initiated]
                DatabaseOptions = OptionsBuilder.Options;//used for options class for our database context as we specify that online 26 - ref to 32
            }
            public DbContextOptionsBuilder<DatabaseContext> OptionsBuilder { get; set; }
            public DbContextOptions<DatabaseContext> DatabaseOptions { get; set; }
            private AppConfiguration Settings { get; set; }
        }
        // We want the DatabaseContext to expect to have an DbContextOptions object available when it is created:
        // So We have set a static OptionsBuild Constructor:
        // SO IN  OTHER WORDS: 
        // A static constructor is called automatically to initialize the class before the first instance is created or any static members are referenced
        public static OptionsBuild Options = new OptionsBuild();

        //DatabaseContext CONSTRUCTOR:
        // Initializes a new instance of DbContext (DatabaseContext) but with specified OPTIONS.
        // But we will always simply just use the static OptionsBuild Options, as they are static and ready to go.
        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options) { }

        //Our DbSets [Entities].
        public DbSet<Applicant> Applicants { get; set; }
        public DbSet<Application> Applications { get; set; }
        public DbSet<ApplicationStatus> ApplicationStatuses { get; set; }
        public DbSet<Grade> Grades { get; set; }

        public DbSet<Student> Students { get; set; }

        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    //SET CUSTOM DEFAULT VALUE ON CREATION
        //    //MODIFIED DATE: 
        //    DateTime modifiedDate = new DateTime(1900, 1, 1);

        //    #region Applicant
        //    modelBuilder.Entity<Applicant>().ToTable("applicant");
        //    //Primary Key & Identity Column
        //    modelBuilder.Entity<Applicant>().HasKey(ap => ap.Applicant_ID);
        //    modelBuilder.Entity<Applicant>().Property(ap => ap.Applicant_ID).UseIdentityColumn(1, 1).IsRequired().HasColumnName("applicant_id");
        //    //COLUMN SETTINGS
        //    modelBuilder.Entity<Applicant>().Property(ap => ap.Applicant_Name).IsRequired(true).HasMaxLength(100).HasColumnName("applicant_name");
        //    modelBuilder.Entity<Applicant>().Property(ap => ap.Applicant_Surname).IsRequired(true).HasMaxLength(100).HasColumnName("applicant_surname");
        //    modelBuilder.Entity<Applicant>().Property(ap => ap.Applicant_BirthDate).IsRequired(true).HasColumnName("applicant_birthdate");
        //    modelBuilder.Entity<Applicant>().Property(ap => ap.Contact_Email).IsRequired(false).HasMaxLength(250).HasColumnName("contact_email");//(no Applicant_)Will be guardians/parents Email
        //    modelBuilder.Entity<Applicant>().Property(ap => ap.Contact_Number).IsRequired(true).HasMaxLength(25).HasColumnName("contact_number");//(no Applicant_)Might not be the applicants email, could be guardians/parents
        //    modelBuilder.Entity<Applicant>().Property(ap => ap.Applicant_CreationDate).IsRequired(true).HasDefaultValue(DateTime.UtcNow).HasColumnName("applicant_creationdate");
        //    modelBuilder.Entity<Applicant>().Property(ap => ap.Applicant_ModifiedDate).IsRequired(true).HasDefaultValue(modifiedDate).HasColumnName("applicant_modifieddate");
        //    //RelationShips
        //    modelBuilder.Entity<Applicant>()
        //           .HasMany<Application>(app => app.Applications)
        //           .WithOne(ap => ap.Applicant)
        //           .HasForeignKey(app => app.Applicant_ID)
        //           .OnDelete(DeleteBehavior.Restrict);//Can't delete an applicants info Ever, We can update it though.
        //    #endregion

        //    #region Application Status
        //    modelBuilder.Entity<ApplicationStatus>().ToTable("application_status");
        //    //Primary Key & Identity Column
        //    modelBuilder.Entity<ApplicationStatus>().HasKey(apps => apps.ApplicationStatus_ID);
        //    modelBuilder.Entity<ApplicationStatus>().Property(apps => apps.ApplicationStatus_ID).UseIdentityColumn(1, 1).IsRequired().HasColumnName("application_status_id");
        //    //COLUMN SETTINGS
        //    modelBuilder.Entity<ApplicationStatus>().HasIndex(apps => apps.ApplicationStatus_Name).IsUnique(); // Application Status Name is Unique
        //    modelBuilder.Entity<ApplicationStatus>().Property(apps => apps.ApplicationStatus_Name).IsRequired(true).HasMaxLength(100).HasColumnName("application_status_name");
        //    modelBuilder.Entity<ApplicationStatus>().Property(apps => apps.ApplicationStatus_CreationDate).IsRequired(true).HasDefaultValue(DateTime.UtcNow).HasColumnName("application_status_creationdate");
        //    modelBuilder.Entity<ApplicationStatus>().Property(ap => ap.ApplicationtStatus_ModifiedDate).IsRequired(true).HasDefaultValue(modifiedDate).HasColumnName("application_status_modifieddate");

        //    //RelationShips
        //    modelBuilder.Entity<ApplicationStatus>()
        //           .HasMany<Application>(app => app.Applications)
        //           .WithOne(apps => apps.ApplicationStatus)
        //           .HasForeignKey(app => app.ApplicationStatus_ID)
        //           .OnDelete(DeleteBehavior.Restrict);//Can't delete an ApplicationStatus, We can update it though.
        //    #endregion

        //    #region Grade
        //    modelBuilder.Entity<Grade>().ToTable("grade");
        //    //Primary Key & Identity Column
        //    modelBuilder.Entity<Grade>().HasKey(g => g.Grade_ID);
        //    modelBuilder.Entity<Grade>().Property(g => g.Grade_ID).UseIdentityColumn(1, 1).IsRequired().HasColumnName("grade_id");
        //    //COLUMN SETTINGS
        //    modelBuilder.Entity<Grade>().Property(g => g.Grade_Name).IsRequired(true).HasMaxLength(100).HasColumnName("grade_name");
        //    modelBuilder.Entity<Grade>().Property(g => g.Grade_Number).IsRequired(true).HasColumnName("grade_number");
        //    modelBuilder.Entity<Grade>().HasIndex(g => g.Grade_Name).IsUnique(); // Grade Name is Unique
        //    modelBuilder.Entity<Grade>().HasIndex(g => g.Grade_Number).IsUnique(); // Grade Number is Unique
        //    modelBuilder.Entity<Grade>().Property(g => g.Grade_Capacity).IsRequired(true).HasColumnName("grade_capacity");
        //    modelBuilder.Entity<Grade>().Property(g => g.Grade_CreationDate).IsRequired(true).HasDefaultValue(DateTime.UtcNow).HasColumnName("grade_creationdate");
        //    modelBuilder.Entity<Grade>().Property(g => g.Grade_ModifiedDate).IsRequired(true).HasDefaultValue(modifiedDate).HasColumnName("grade_modifieddate");

        //    //RelationShips
        //    modelBuilder.Entity<Grade>()
        //           .HasMany<Application>(g => g.Applications)
        //           .WithOne(app => app.Grade)
        //           .HasForeignKey(app => app.Grade_ID)
        //           .OnDelete(DeleteBehavior.Restrict);//Can't delete a Grade Ever, We can update it though.
        //    #endregion

        //    #region Application
        //    modelBuilder.Entity<Application>().ToTable("application");
        //    //Primary Key & Identity Column
        //    modelBuilder.Entity<Application>().HasKey(app => app.Application_ID);
        //    modelBuilder.Entity<Application>().Property(app => app.Application_ID).UseIdentityColumn(1, 1).IsRequired().HasColumnName("application_id");
        //    //COLUMN SETTINGS
        //    modelBuilder.Entity<Application>().Property(app => app.Applicant_ID).IsRequired(true).HasColumnName("applicant_id");
        //    modelBuilder.Entity<Application>().Property(app => app.Grade_ID).IsRequired(true).HasColumnName("grade_id");
        //    modelBuilder.Entity<Application>().Property(app => app.ApplicationStatus_ID).IsRequired(true).HasColumnName("application_status_id");
        //    modelBuilder.Entity<Application>().Property(app => app.Application_CreationDate).IsRequired(true).HasDefaultValue(DateTime.UtcNow).HasColumnName("application_creationdate");
        //    modelBuilder.Entity<Application>().Property(app => app.Application_ModifiedDate).IsRequired(true).HasDefaultValue(modifiedDate).HasColumnName("application_modifieddate");
        //    modelBuilder.Entity<Application>().Property(app => app.SchoolYear).IsRequired(true).HasColumnName("application_schoolyear");
        //    //Relationships

        //    //Applicant link
        //    modelBuilder.Entity<Application>()
        //         .HasOne<Applicant>(app => app.Applicant)
        //         .WithMany(ap => ap.Applications)//CAN HAVE MANY APPLICATIONS
        //         .HasForeignKey(app => app.Applicant_ID)
        //         .OnDelete(DeleteBehavior.NoAction);//Can delete an application.

        //    //Grade link
        //    modelBuilder.Entity<Application>()
        //         .HasOne<Grade>(app => app.Grade)
        //         .WithMany(ap => ap.Applications)//Grade is linked to many applications
        //         .HasForeignKey(app => app.Grade_ID)
        //         .OnDelete(DeleteBehavior.NoAction);//Can delete an application.

        //    //Status link
        //    modelBuilder.Entity<Application>()
        //        .HasOne<ApplicationStatus>(app => app.ApplicationStatus)
        //        .WithMany(ap => ap.Applications)//Status is linked to many applications
        //        .HasForeignKey(app => app.ApplicationStatus_ID)
        //        .OnDelete(DeleteBehavior.NoAction);//Can delete an application.
        //    #endregion
        //}
    }
}