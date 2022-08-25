namespace SchoolApi.Domain.Entity
{
    public abstract class BaseEntity
    {        
        public virtual int Id { get; set; }
        public virtual bool Active { get; set; }
        public virtual int CreateBy { get; set; }
        public virtual DateTime CreateDate { get; set; }
        public virtual int ModifBy { get; set; }
        public virtual DateTime ModifDate { get; set; }
    }
}
