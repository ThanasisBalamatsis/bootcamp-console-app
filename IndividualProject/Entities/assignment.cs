namespace IndividualProject.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Assignment
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Assignment()
        {
            courses = new HashSet<Course>();
        }

        [Key]
        public int assignment_id { get; set; }

        [Required]
        [StringLength(50)]
        public string title { get; set; }

        [Required]
        [StringLength(50)]
        public string description { get; set; }

        [Column(TypeName = "date")]
        public DateTime? sub_date { get; set; }

        public int? oral_mark { get; set; }

        public int? total_mark { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Course> courses { get; set; }

        public override string ToString()
        {
            return ($"\tAssignment ID: {this.assignment_id}," +
                    $" \ttitle: {this.title}," +
                    $" \tdescription: {this.description}," +
                    $" \tsubmission date: {this.sub_date}," +
                    $" \toral mark: {this.oral_mark}" +
                    $" \ttotal mark: {this.total_mark} ");
        }
    }
}
