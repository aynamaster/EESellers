import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Product } from '../model/product.model';
import { Observable } from '../../../node_modules/rxjs/Observable';
import 'rxjs/add/operator/map';
import 'rxjs/add/operator/catch';
import 'rxjs/add/operator/retry';
import 'rxjs/add/observable/of';
import 'rxjs';
import { Seller } from '../model/seller.model';

@Injectable()
export class SellerService {

  configUrl = 'http://localhost:50729/api';


  constructor(private http: HttpClient) { }

  getSellers() {
    var routeApi = "/Sellers";
    return this.http.get<Seller[]>(this.configUrl+routeApi);
  }

  getSeller(id) {
    var routeApi = "/Sellers/"+id;
    return this.http.get<Seller[]>(this.configUrl+routeApi);
  }

}
