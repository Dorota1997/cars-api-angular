export class Order {
  public id: number;
  public components: string;
  public orderDate: string;
  public dealer: string;
  public dealerId: number;
}

export class Orders {
  public data: Order[];
  public pageNumber: number;
  public pageSize: number;
  public nextPage: string;
  public previousPage: string;
}

export class AddOrder {
  public components: string;
  public orderDate: string;
  public dealerId: number;
}
