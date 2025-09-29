import { ComponentFixture, TestBed } from '@angular/core/testing';

import { TransactionsLayoutComponent } from './transactions-layout.component';

describe('TransactionsLayoutComponent', () => {
  let component: TransactionsLayoutComponent;
  let fixture: ComponentFixture<TransactionsLayoutComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [TransactionsLayoutComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(TransactionsLayoutComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
