export class Dealer {
  public id: number;
  public name: string;
  public address: string;
  public postalCode: string;
  public country: string;
}

export class Dealers {
  public data: Dealer[];
  public pageNumber: number;
  public pageSize: number;
  public nextPage: string;
  public previousPage: string;
}

export class AddDealer {
  public name: string;
  public address: string;
  public postalCode: string;
  public country: string;
}
