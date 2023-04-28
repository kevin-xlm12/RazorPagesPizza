using System.ComponentModel.DataAnnotations;

namespace RazorPagesPizza.Models;
public class Pizza
{

    public int Id{get;set;}

    [Required]
    public string? Name{set;get;}
    public PizzaSize Size {set;get;}
    public bool IsGlutenFree {set;get;}

     [Range(0.01, 9999.99)]
     public decimal Price {set;get;}   
}

public enum PizzaSize{Small, Medium, Large }

public  class PizzaService
{
    public List<Pizza> Pizzas { get; }
    public int nextId = 3;
    public PizzaService()
    {
        Pizzas = new List<Pizza>
                {
                    new Pizza { Id = 1, Name = "Classic Italian", Price=20.00M, Size=PizzaSize.Large, IsGlutenFree = false },
                    new Pizza { Id = 2, Name = "Veggie", Price=15.00M, Size=PizzaSize.Small, IsGlutenFree = true }
                };
    }

    public static List<Pizza> GetAll() => Pizzas;

    public static  Pizza? Get(int id) => Pizzas.FirstOrDefault(p => p.Id == id);

    public  void Add(Pizza pizza)
    {
        pizza.Id = nextId++;
        Pizzas.Add(pizza);
    }

    public  void Delete(int id)
    {
        var pizza = Get(id);
        if (pizza is null)
            return;

        Pizzas.Remove(pizza);
    }

    public  void Update(Pizza pizza)
    {
        var index = Pizzas.FindIndex(p => p.Id == pizza.Id);
        if (index == -1)
            return;

        Pizzas[index] = pizza;
    }
}

