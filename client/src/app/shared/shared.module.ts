import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { PagingHeaderComponent } from './components/paging-header/paging-header.component';
import { PagingBodyComponent } from './components/paging-body/paging-body.component';
import { PaginationModule } from 'ngx-bootstrap/pagination';



@NgModule({
  declarations: [
    PagingHeaderComponent,
    PagingBodyComponent
  ],
  imports: [
    CommonModule,
    PaginationModule.forRoot(),
  ],
  exports: [
    PagingHeaderComponent,
    PagingBodyComponent,
    PaginationModule
  ]
})
export class SharedModule { }
