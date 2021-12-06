import { Component, OnInit } from '@angular/core';
import { Logininterface } from '../logininterface';
import { ProductServiceService } from '../product-service.service';
import { Router } from '@angular/router';
@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {

 
  logInfo:Logininterface[];
  constructor(private httpsvc:ProductServiceService,private router:Router) { 
    this.logInfo = []
     }

     getUser(user:Logininterface)
     {
      
      this.httpsvc.getUser(user).subscribe(
        response =>{
        alert("Login successful");
       this.router.navigate(['/newbooks']);
      },error =>{
        alert("User does not exist")
      })

      }
     

  ngOnInit(): void {
  }

}
