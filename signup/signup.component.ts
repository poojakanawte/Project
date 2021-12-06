import { Component, OnInit } from '@angular/core';

import {FormGroup,FormBuilder} from '@angular/forms';

import { Logininterface } from '../logininterface';
import { ProductServiceService } from '../product-service.service';


  



@Component({

  selector: 'app-signup',

  templateUrl: './signup.component.html',

  styleUrls: ['./signup.component.css']

})

export class SignupComponent implements OnInit {

  
  constructor(private httsvc:ProductServiceService) { }
sendUserData(user:Logininterface)
{
  this.httsvc.signupdata(user).subscribe(
  
    response =>{
      alert("Sign Up successful")
    },error =>{
      alert("User aleready exist")
    }
   
  )
  

}


 

  ngOnInit(): void { 
   


  }

}