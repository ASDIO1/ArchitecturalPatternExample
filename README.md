# ArchitecturalPatternExample
This is an architectural pattern implementation and design with c4 model for studying purposes

## Explanation

-  This application is about a PastryShop(pasteleria) which has products (cakes, pies, cupcakes, etc).
A Pastry shop obviously has more domains than just products but, for this simple example I just used the products domain.

-  The idea is that the administartor of the pastry shop should be able to manipulate the products registered in the database, which are the products that will be shown to the user.  The administrator basicly has the ability to do  CRUD operations over the products.

-  Since this is just an example project and no UI was needed, I decided to model the interaction the administrator user has with the API, using an external app/system like Postman.

-  For this topic, I chose to model and implemented a **Layered Monolithic Architecture**, because it's simple and adjusts to the necesities of this simple example.

## Usage guide

-  The API is totally functional and as explained in the previous point, since there's no UI, the only way to interact with the API is by using an app that helps doing HTTP request
like Postman.

- I will list the http requests that can be done in case you want to test the APIs functionality:
  -  **GET** all products**: http://localhost:3030/api/products
  -  **GET a single product**: http://localhost:3030/api/products/{id}    
  -  **DELETE a single product**: http://localhost:3030/api/products/{id}
  -  **UPDATE a single product**: http://localhost:3030/api/products/{id}
  -  **CREATE a single product**: http://localhost:3030/api/products
  -  **GET products filtered by a query param (by id, price, name or description)**: http://localhost:3030/api/categories/5?orderby=price

(The Update and Create requests need a JSON body to work correctly)
(the iDs are are not in order so you could try id 9 for example, or look for an ID doing a 'GET all products' request)

-  To run the program just open the .sln file and start the program with IIS. This should automaticly run the API.
