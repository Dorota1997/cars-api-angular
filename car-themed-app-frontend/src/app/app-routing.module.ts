import { OrdersComponent } from '@components/orders/orders.component';
import { DealersComponent } from '@components/dealers/dealers.component';
import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

const routes: Routes = [
  {
    path: 'dealers',
    component: DealersComponent,
  },
  {
    path: 'orders',
    component: OrdersComponent,
  },
  {
    path: '**',
    redirectTo: '/dealers',
  },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
