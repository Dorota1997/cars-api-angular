import {
  Directive,
  Host,
  HostListener,
  Optional,
  Renderer2,
  Self,
  ViewContainerRef,
} from '@angular/core';
import { MatPaginator, PageEvent } from '@angular/material/paginator';

@Directive({
  selector: '[appPageButtons]',
})
export class PageButtonsDirective {
  @HostListener('page', ['$event'])
  onChange(event: PageEvent) {
    this.initPageRange();
  }

  constructor(
    @Host() @Self() @Optional() private matPag: MatPaginator,
    private vr: ViewContainerRef,
    private ren: Renderer2
  ) {
    setTimeout(() => {
      this.initPageRange();
    }, 0);
  }

  private initPageRange(): void {
    const pageRange = this.vr.element.nativeElement.querySelector(
      'div.mat-paginator-range-actions > div.mat-paginator-range-label'
    );
    pageRange.innerHTML = '';

    const pageCount = this.pageCount(this.matPag.length, this.matPag.pageSize);

    for (let i = 0; i < pageCount; i++) {
      this.ren.appendChild(
        pageRange,
        this.createPage(i, this.matPag.pageIndex)
      );
    }
  }

  private createPage(i: number, pageIndex: number): any {
    const linkBtn = this.ren.createElement('mat-button');
    this.ren.addClass(linkBtn, 'mat-icon-button');

    this.ren.listen(linkBtn, 'click', (evt) => {
      this.switchPage(i);
    });

    const text = this.ren.createText(i + 1 + '');
    this.ren.addClass(linkBtn, 'mat-custom-page');

    i === pageIndex
      ? this.ren.setStyle(linkBtn, 'background-color', '#f2f2f2')
      : this.ren.setStyle(linkBtn, 'background-color', '#ffffff');

    this.ren.appendChild(linkBtn, text);
    return linkBtn;
  }

  private pageCount(length: number, pageSize: number): number {
    return Math.ceil(length / pageSize);
  }

  private switchPage(i: number): void {
    this.matPag.pageIndex = i;
    this.matPag._changePageSize(this.matPag.pageSize);
  }
}
