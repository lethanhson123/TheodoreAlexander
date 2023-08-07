import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ItemActiveByBrandComponent } from './item-active-by-brand.component';

describe('ItemActiveByBrandComponent', () => {
  let component: ItemActiveByBrandComponent;
  let fixture: ComponentFixture<ItemActiveByBrandComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ItemActiveByBrandComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(ItemActiveByBrandComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
