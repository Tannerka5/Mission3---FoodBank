using System;

public class FoodItem   // Represents one food item in inventory
{
    public string Name { get; set; }          // Food name
    public string Category { get; set; }      // e.g., Canned, Dairy
    public int Quantity { get; set; }         // How many units
    public DateTime ExpirationDate { get; set; }  // When it expires

    // Constructor: require all fields when creating a FoodItem
    public FoodItem(string name, string category, int quantity, DateTime expirationDate)
    {
        Name = name;
        Category = category;
        Quantity = quantity;
        ExpirationDate = expirationDate;
    }

    // Formatted string for printing to console
    public override string ToString()
    {
        return $"Name: {Name}, Category: {Category}, Quantity: {Quantity}, Expiration: {ExpirationDate.ToShortDateString()}";
    }
}
