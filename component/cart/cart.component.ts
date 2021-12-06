import { Component, OnInit } from '@angular/core';



import { CartInterface } from 'src/app/cart-interface';
import { ProductServiceService } from 'src/app/product-service.service';
//import { Addtocart } from 'src/app/addtocart';
//import { ProductServiceService } from 'src/app/product-service.service';

@Component({
  selector: 'app-cart',
  templateUrl: './cart.component.html',
  styleUrls: ['./cart.component.css']
})
export class CartComponent implements OnInit {

  productInfo:CartInterface[]
 
  constructor(private httpsvc:ProductServiceService) { 
    this.productInfo = []
   
  }



  ngOnInit(): void {
    this.httpsvc.displayProduct().subscribe(
      response => {
        this.productInfo = response;
        

      },error =>{
        console.log("error ");
      }
    )

    
   

  }
  deleteDataMethod(productId :number)
  {
    this.httpsvc.deleteData(productId).subscribe(
      response => {
        alert("data deleted");
      },error=>{
        console.log("error");
      }
    )
  }
 /* emptycart(cart:CartInterface){

    this.httpsvc.removeAllCart(cart).subscribe(
      response=>{
        alert("data deleted");
      },error=>{
        console.log("error");
      }
    );
  }
  */
  
}
