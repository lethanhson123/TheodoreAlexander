import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ItemActiveIsBestSellerComponent } from './item-active-is-best-seller.component';

describe('ItemActiveIsBestSellerComponent', () => {
  let component: ItemActiveIsBestSellerComponent;
  let fixture: ComponentFixture<ItemActiveIsBestSellerComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ItemActiveIsBestSellerComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(ItemActiveIsBestSellerComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
