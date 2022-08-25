namespace SchoolApi.Domain.Enum
{
    public enum Status
    {
        Ok=200,
        NoContent=204,
        Created=201,
        Accepted=201,
        BadRequest=400,
        Unauthorized= 401,
        Forbidden=403,
        NotFound=404,
        NotAllowed=405,
        Gone=410,
        InternalServerError=500
    }
}
