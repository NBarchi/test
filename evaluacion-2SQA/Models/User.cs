namespace UserApp.Models
{
    public class User
    {
        public string Gender { get; set; }  
        public Name Name { get; set; }  
        public Location Location { get; set; }  
        public string Email { get; set; }  
        public string Phone { get; set; }  
        public string Cell { get; set; }  
        public DateOfBirth Dob { get; set; }  
        public Picture Picture { get; set; }  
        public string Nationality { get; set; }  
    }

    public class Name
    {
        public string Title { get; set; }  
        public string First { get; set; }  
        public string Last { get; set; }  
    }

    public class Location
    {
        public Street Street { get; set; }  
        public string City { get; set; }  
        public string State { get; set; }  
        public string Country { get; set; }  
        public string Postcode { get; set; }  
        public Coordinates Coordinates { get; set; }  
        public Timezone Timezone { get; set; }  
    }

    public class Street
    {
        public int Number { get; set; }  
        public string Name { get; set; }  
    }

    public class Coordinates
    {
        public string Latitude { get; set; }  
        public string Longitude { get; set; }  
    }

    public class Timezone
    {
        public string Offset { get; set; }  
        public string Description { get; set; }  
    }

    public class DateOfBirth
    {
        public string Date { get; set; }  
        public int Age { get; set; }  
    }

    public class Picture
    {
        public string Large { get; set; }  
        public string Medium { get; set; }  
        public string Thumbnail { get; set; }  
    }

    public class UserResponse
    {
        public List<User> Results { get; set; }
    }
}

