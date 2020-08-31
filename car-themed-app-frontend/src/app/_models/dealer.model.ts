export interface IDealer {
  id: number;
  name: string;
  address: string;
  postalCode: string;
  country: string;
}

export interface IDealers {
  data: Array<IDealer>;
  pageNumber: number;
  pageSize: number;
  nextPage: string;
  previousPage: string;
}
