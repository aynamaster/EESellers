import { Component, OnInit } from '@angular/core';
import { Product } from '../../model/product.model';
import { ProductService } from '../../service/product.service';
import { SellerService } from '../../service/seller.service';
import { FormsModule, ReactiveFormsModule  } from '../../../../node_modules/@angular/forms';
import { Angular5Csv } from 'angular5-csv/Angular5-csv';

import {  Observable} from 'rxjs/Observable';


import 'rxjs/add/operator/do';
import 'rxjs/add/operator/filter';
import 'rxjs/add/operator/map';
import { Seller } from '../../model/seller.model';
import { Sales } from '../../model/sales.model';
import { SalesService } from '../../service/sales.service';

@Component({
  selector: 'app-dashboard',
  templateUrl: './dashboard.component.html',
  styleUrls: ['./dashboard.component.css']
})
export class DashboardComponent implements OnInit {
  title = 'Dashboard';

  //Formulários
  productFormU : Product;
  
  //Modelos
  products : Product [];
  product : Product [];

  sellers : Seller[];
  seller: Seller[];

  sales: Sales[];
  sale: Sales[];

  //Variáveis de configuração
  editMode = false;
  editObject: any;


  constructor(private productService: ProductService, private sellerService: SellerService, private salesService: SalesService) { }

  ngOnChange(){
    // this will be called each time userInput changes
    this.search(); 
  }

  ngOnInit() {

    this.getProdutos();
    this.getVendedores();
    this.getVendas();
    
  }


  //Funções de configuração
  editModeChange(obj){
    if(!this.editMode){
      this.editMode = true;
      this.editObject = this.getProduto(obj.cdProduto);
    } else {
      this.editMode = false;
    }
  }

  search(){
    this.getProdutos();
    this.getVendedores();
    this.getVendas();
  }

  trackByFn(index, item) {
    return index;
  }

  //PRODUTOS

  // GET
  getProdutos () {
    this.productService.getProducts().subscribe(
        data => {
          this.products = data;
        }), err => {
          console.log(err);
        };
  }

  // GET/id
  getProduto (id) {
    this.productService.getProduct(id).subscribe(
        data => {
          this.product = data;
        }), err => {
          console.log(err);
        };
  }


  // PUT
  onSubmitProd(id, form : Product){
        this.productService.putProduct(id, form).subscribe(
            data => {
            console.log('Product updated:'+data)
          }
      );
      this.editModeChange(form);
  }

  //VENDEDORES

  //GET
  getVendedores() {
    this.sellerService.getSellers().subscribe(
        data => {
          this.sellers = data;
        }), err => {
          console.log(err);
        };
  }

  // GET/id
  getVendedor (id) {
    this.sellerService.getSeller(id).subscribe(
        data => {
          this.seller = data;
        }), err => {
          console.log(err);
        };
  }


  //VENDAS

  // GET
  getVendas() {
    this.salesService.getSales().subscribe(
        data => {
          this.sales = data;
        }), err => {
          console.log(err);
        };
  }


  // GET/id
  getVenda (id) {
    this.salesService.getSale(id).subscribe(
        data => {
          this.sale = data;
        }), err => {
          console.log(err);
        };
  }

  //Ordernações
  comparerPrice(a, b){
    if(a.vlrUnitario > b.vlrUnitario){
      return -1;
    }
    if(a.vlrUnitario < b.vlrUnitario){
      return 1;
    }
    return 0;
  }

  comparerAmount(a, b){
    if(a.qtdEstoque > b.qtdEstoque){
      return -1;
    }
    if(a.qtdEstoque < b.qtdEstoque){
      return 1;
    }
    return 0;
  }

  orderByPrice(){
    this.products.sort(this.comparerPrice);
    console.log(this.products);
  }

  orderByAmount(){
    this.products.sort(this.comparerAmount);
    console.log(this.products);
  }

  //Export
  //Função de exportação de relatório de vendas
  ExcelReportSals(){
    var options = { 
      fieldSeparator: ';',
      quoteStrings: '"',
      decimalseparator: '.',
      showTitle: false,
      useBom: false,
      noDownload: false,
      headers: ["id", "Cod. Vendedor", "Cod. Produto", "Data de Criacao","Data de Atualizacao", "Valor de Comissao"]
    };


    var data = this.sales;
    new Angular5Csv(data, "Report_"+Date.now(), options);
  }
  

}
