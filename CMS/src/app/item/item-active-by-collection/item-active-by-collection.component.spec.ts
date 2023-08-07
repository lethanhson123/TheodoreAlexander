import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ItemActiveByCollectionComponent } from './item-active-by-collection.component';

describe('ItemActiveByCollectionComponent', () => {
  let component: ItemActiveByCollectionComponent;
  let fixture: ComponentFixture<ItemActiveByCollectionComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ItemActiveByCollectionComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(ItemActiveByCollectionComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
