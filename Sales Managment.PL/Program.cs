// See https://aka.ms/new-console-template for more information
using Sales_Managment.DAL.Entities;
using Sales_Managment.PL;
using System_Managment.BusinessLogic.Repositories;



#region CustomerManagment

CustomerManagment customerManagment = new CustomerManagment();

#region AddCustomer
//var customer = new Customer { ID = 4, Name = "ziad", PhoneNumber="0123060514", Address =new Address { Country="Egypt", City="cairo", District="feisal" } };
//customerManagment.Create(customer);

#endregion

#region update customer
//var updatedCustomer = new Customer { ID = 4, Name = "ziad", PhoneNumber="0123060514", Address =new Address { Country="NewEgypt", City="cairo", District="feisal", PostalCode="21352" } };
//customerManagment.Update(updatedCustomer.ID, updatedCustomer);

#endregion

#region Delete Customer
//customerManagment.Delete(3);
#endregion

//customerManagment.RetrieveAllCustomers();

#endregion

#region Category Managment

CategoryManagment CategoryManagment = new CategoryManagment();

#region AddCategory
//var Category = new Category { Id = 3, Name = "3-style" };
//CategoryManagment.Create(Category);

#endregion

#region update Category
//var updatedCategory = new Category { Id = 3, Name = "electronics" };
//CategoryManagment.Update(updatedCategory.Id, updatedCategory);

#endregion

#region Delete Category
//CategoryManagment.Delete(3);
#endregion

//CategoryManagment.RetrieveAllCategorys();

#endregion

#region Brand Managment


//BrandManagment BrandManagment = new BrandManagment();

#region AddBrand
//var Brand = new Brand { Id = 3, Name = "c-brand" };
//BrandManagment.Create(Brand);

#endregion

#region update Brand
//var updatedBrand = new Brand { Id = 4, Name = "electronics" };
//BrandManagment.Update(updatedBrand.Id, updatedBrand);

#endregion

#region Delete Brand
//BrandManagment.Delete(3);
#endregion

//BrandManagment.RetrieveAllBrands();
#endregion

#region Product Managment


//ProductManagment ProductManagment = new ProductManagment();

#region AddProduct
//var Product = new Product { Id = 3, Name = "c-Product" , Price = 38 , Category = new Category { Id = 1 , Name = "a-style"}, Brand = new Brand { Id = 1 , Name = "a-brand"} };
//ProductManagment.Create(Product);

#endregion

#region update Product
//var updatedProduct = new Product { Id = 1, Name = "a-Product", Price = 70, Category = new Category { Id = 2, Name = "b-style" }, Brand = new Brand { Id = 1, Name = "a-brand" } };
//ProductManagment.Update(updatedProduct.Id, updatedProduct);

#endregion

#region Delete Product
//ProductManagment.Delete(3);
#endregion

#region Add Product To cart

//ProductManagment.AddToCart(2, 2, 1 );
#endregion

//ProductManagment.RetrieveAllProducts();
#endregion


#region Cart Managment

// Preview cart content 

//CartManagment cartManagment = new CartManagment();

//increase product count in cart
//cartManagment.IncreaseCountByOne(2, 2, 1);

// decrease product count in cart
//cartManagment.DecreaseCountByOne(2, 2, 1);

//cartManagment.RetrieveAllCarts();




#endregion

#region OrderManagment
OrderManagment OrderManagment = new OrderManagment();

#region Make Order

////1- first he should sent a customerid and carid
////2- then we will create order without(confirmation it)
OrderManagment.MakeOrder(1, 1);

#endregion

#endregion



