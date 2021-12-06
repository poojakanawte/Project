import { Component, OnInit } from '@angular/core';

import { BookInterface } from 'src/app/book-interface';
import { CartInterface } from 'src/app/cart-interface';
import { ProductServiceService } from 'src/app/product-service.service';

@Component({
  selector: 'app-book',
  templateUrl: './book.component.html',
  styleUrls: ['./book.component.css']
})
export class BookComponent implements OnInit {

 
  bookInfo:BookInterface[];
  constructor(private httpsvc:ProductServiceService) { 
    this.bookInfo = []
    
  }


  ngOnInit(): void {
    this.httpsvc.displayBookTable().subscribe(
      response =>{
        
        this.bookInfo = response
        console.log(this.bookInfo)
      }, error =>{
        console.log(error)
      }
    )
    
  }

  addCartList(cart:CartInterface)
  {
    
    this.httpsvc.addTocart(cart).subscribe((data)=>{
      
      console.log("addtocart===>",data);
    })
  }
 /* deleteData(cart:CartInterface)
  {
    this.httpsvc.deleteFromCart(cart).subscribe((data: any)=>{
      console.log("deletedata====>",data);
    })
  }
  */
  
  
 

}
