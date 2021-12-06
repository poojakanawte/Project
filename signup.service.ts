import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Logininterface } from './logininterface';

@Injectable({
  providedIn: 'root'
})
export class SignupService {
  serverUrl = "https://localhost:44337/api";

  constructor(private httpsvc:HttpClient) { }

  signupdata(user :Logininterface):Observable<Logininterface>{

  
  

    const body=JSON.stringify(user);
   
    console.log(body)
    const reqopts = {
     headers:new HttpHeaders({"content-Type":"application/json"})
      
       
 
    }
 
   return this.httpsvc.post<Logininterface>(this.serverUrl+"/UserLogs",body,reqopts)
  }
  
 
}
