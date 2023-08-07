import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ItemInsertOrUpdateComponent } from './item-insert-or-update.component';

describe('ItemInsertOrUpdateComponent', () => {
  let component: ItemInsertOrUpdateComponent;
  let fixture: ComponentFixture<ItemInsertOrUpdateComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ItemInsertOrUpdateComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(ItemInsertOrUpdateComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
