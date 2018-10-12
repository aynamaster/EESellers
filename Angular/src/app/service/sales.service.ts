import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Product } from '../model/product.model';
import { Observable } from '../../../node_modules/rxjs/Observable';
import 'rxjs/add/operator/map';
import 'rxjs/add/operator/catch';
import 'rxjs/add/operator/retry';
import 'rxjs/add/observable/of';
import 'rxjs';
import { Sales } from '../model/sales.model';

@Injectable()
export class SalesService {

  configUrl = 'http://localhost:50729/api';


  constructor(private http: HttpClient) { }

  getSales() {
    var routeApi = "/Sales";
    return this.http.get<Sales[]>(this.configUrl+routeApi);
  }

  getSale(id) {
    var routeApi = "/Sales/"+id;
    return this.http.get<Sales[]>(this.configUrl+routeApi);
  }

  postSale(sale: Sales) {
    var dateNow = ""+Date.now().toString;
    const body = {
      cdVendedor: sale.cdVendedor,
      cdProduto: sale.cdProduto,
      dataCriacao: new Date().toLocaleDateString(),
      dataUltimaAlteracao: new Date().toLocaleDateString()
    }
    var routeApi = "/Sales";
    return this.http.post<Sales[]>(this.configUrl+routeApi, body);
  }

}
