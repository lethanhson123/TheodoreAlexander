import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ItemActiveIsCFPItemComponent } from './item-active-is-cfpitem.component';

describe('ItemActiveIsCFPItemComponent', () => {
  let component: ItemActiveIsCFPItemComponent;
  let fixture: ComponentFixture<ItemActiveIsCFPItemComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ItemActiveIsCFPItemComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(ItemActiveIsCFPItemComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
