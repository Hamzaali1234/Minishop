using Domain.Models;
using Infrastructure.Repositories;

ProductRepository productRepository = new ProductRepository();
CategoryRepository categoryRepository = new CategoryRepository();

while (true)
{
    Console.WriteLine("\n===== MINI SHOP =====");
    Console.WriteLine("1. Show all products");
    Console.WriteLine("2. Get product by ID");
    Console.WriteLine("3. Add product");
    Console.WriteLine("4. Update product");
    Console.WriteLine("5. Delete product");
    Console.WriteLine("6. Show all categories");
    Console.WriteLine("7. Add category");
    Console.WriteLine("8. Delete category");
    Console.WriteLine("9. Exit");

    Console.Write("Choose: ");
    int choice = Convert.ToInt32(Console.ReadLine());

    if (choice == 1)
    {
        var products = productRepository.GetAll();

        foreach (var product in products)
        {
            Console.WriteLine(
                $"Id: {product.Id}, Name: {product.Name}, Price: {product.Price}, Quantity: {product.Quantity}, CategoryId: {product.CategoryId}");
        }
    }
    else if (choice == 2)
    {
        Console.Write("Enter product ID: ");
        int id = Convert.ToInt32(Console.ReadLine());

        var product = productRepository.GetById(id);

        if (product == null)
        {
            Console.WriteLine("Product not found!");
        }
        else
        {
            Console.WriteLine($"Id: {product.Id}");
            Console.WriteLine($"Name: {product.Name}");
            Console.WriteLine($"Price: {product.Price}");
            Console.WriteLine($"Quantity: {product.Quantity}");
            Console.WriteLine($"Category ID: {product.CategoryId}");
        }
    }
    else if (choice == 3)
    {
        Product product = new Product();

        Console.Write("Enter name: ");
        product.Name = Console.ReadLine()!;

        Console.Write("Enter price: ");
        product.Price = Convert.ToDecimal(Console.ReadLine());

        Console.Write("Enter quantity: ");
        product.Quantity = Convert.ToInt32(Console.ReadLine());

        Console.Write("Enter category ID: ");
        product.CategoryId = Convert.ToInt32(Console.ReadLine());

        productRepository.Add(product);

        Console.WriteLine("Product added successfully!");
    }
    else if (choice == 4)
    {
        Console.Write("Enter product ID: ");
        int id = Convert.ToInt32(Console.ReadLine());

        var product = productRepository.GetById(id);

        if (product == null)
        {
            Console.WriteLine("Product not found!");
        }
        else
        {
            Console.Write("Enter new name: ");
            product.Name = Console.ReadLine()!;

            Console.Write("Enter new price: ");
            product.Price = Convert.ToDecimal(Console.ReadLine());

            Console.Write("Enter new quantity: ");
            product.Quantity = Convert.ToInt32(Console.ReadLine());

            Console.Write("Enter new category ID: ");
            product.CategoryId = Convert.ToInt32(Console.ReadLine());

            productRepository.Update(product);

            Console.WriteLine("Product updated successfully!");
        }
    }
    else if (choice == 5)
    {
        Console.Write("Enter product ID: ");
        int id = Convert.ToInt32(Console.ReadLine());

        productRepository.Delete(id);

        Console.WriteLine("Product deleted!");
    }
    else if (choice == 6)
    {
        var categories = categoryRepository.GetAll();

        foreach (var category in categories)
        {
            Console.WriteLine($"Id: {category.Id}, Name: {category.Name}");
        }
    }
    else if (choice == 7)
    {
        Category category = new Category();

        Console.Write("Enter category name: ");
        category.Name = Console.ReadLine()!;

        categoryRepository.Add(category);

        Console.WriteLine("Category added successfully!");
    }
    else if (choice == 8)
    {
        Console.Write("Enter category ID: ");
        int id = Convert.ToInt32(Console.ReadLine());

        categoryRepository.Delete(id);

        Console.WriteLine("Category deleted!");
    }
    else if (choice == 9)
    {
        Console.WriteLine("Goodbye!");
        break;
    }
    else
    {
        Console.WriteLine("Invalid choice!");
    }
}
