import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Product } from '../model/product.model';
import { Observable } from '../../../node_modules/rxjs/Observable';
import 'rxjs/add/operator/map';
import 'rxjs/add/operator/catch';
import 'rxjs/add/operator/retry';
import 'rxjs/add/observable/of';
import 'rxjs';

@Injectable()
export class ProductService {

  configUrl = 'http://localhost:50729/api';


  constructor(private http: HttpClient) { }

  getProducts() {
    var routeApi = "/Product";
    return this.http.get<Product[]>(this.configUrl+routeApi);
  }

  getProduct(id) {
    var routeApi = "/Product/"+id;
    return this.http.get<Product[]>(this.configUrl+routeApi);
  }

  postProduct(prod: Product) {
    var dateNow = ""+Date.now().toString;
    const body = {
      dsProduto: prod.dsProduto,
      vlrUnitario: prod.vlrUnitario,
      flFisico: prod.flFisico,
      qtdEstoque: prod.qtdEstoque
    }
    var routeApi = "/Product";
    return this.http.post<Product[]>(this.configUrl+routeApi, body);
  }

  putProduct(id, prod: Product) {
    const body = {
      cdProduto: id,
      dsProduto: prod.dsProduto,
      vlrUnitario: prod.vlrUnitario,
      flFisico: prod.flFisico,
      qtdEstoque: prod.qtdEstoque
    }
    var routeApi = "/Product/"+id;
    console.log(routeApi);
    return this.http.put(this.configUrl+routeApi, body);
  }
}
