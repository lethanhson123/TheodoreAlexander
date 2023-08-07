import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ItemActiveIsStockedComponent } from './item-active-is-stocked.component';

describe('ItemActiveIsStockedComponent', () => {
  let component: ItemActiveIsStockedComponent;
  let fixture: ComponentFixture<ItemActiveIsStockedComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ItemActiveIsStockedComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(ItemActiveIsStockedComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
