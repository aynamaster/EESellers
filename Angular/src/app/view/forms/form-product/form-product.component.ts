import { Component, OnInit } from '@angular/core';
import { ProductService } from '../../../service/product.service';
import { Product } from '../../../model/product.model';
import { Sales } from '../../../model/sales.model';
import { Seller } from '../../../model/seller.model';
import { SellerService } from '../../../service/seller.service';
import { FormsModule, ReactiveFormsModule  } from '../../../../../node_modules/@angular/forms';
import { SalesService } from '../../../service/sales.service';

@Component({
  selector: 'app-form-product',
  templateUrl: './form-product.component.html',
  styleUrls: ['./form-product.component.css']
})
export class FormProductComponent implements OnInit {

  products : Product [];

  salesForm : Sales;
  productForm : Product;
  sellers : Seller[];

  constructor(private productService: ProductService, private sellerService: SellerService, private salesService: SalesService) { }

  ngOnInit() {
    this.getProdutos();
    this.getVendedores();
  }

  //Modelos
  getProdutos () {
    this.productService.getProducts().subscribe(
        data => {
          this.products = data;
        }), err => {
          console.log(err);
        };
  }

  getVendedores() {
    this.sellerService.getSellers().subscribe(
        data => {
          this.sellers = data;
          console.log(this.sellers);
        }), err => {
          console.log(err);
        };
  }
  


  //Forms Submit
  //DEPOIS: Poderia ser apenas um submit com mais um parametro da função
  onSubmitSales(form : any){
    console.log(form);
    this.salesService.postSale(form).subscribe(
        data => {
          console.log('Sale created id:'+data)
        }
    );
    location.reload();
  }

  onSubmitProduct(form : any){
    console.log(form);
    this.productService.postProduct(form).subscribe(
        data => {
          console.log('Product created id:'+data)
        }
    );
    location.reload();
  }


}
