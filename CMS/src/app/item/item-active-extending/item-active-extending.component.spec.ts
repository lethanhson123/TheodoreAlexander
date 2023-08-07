import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ItemActiveExtendingComponent } from './item-active-extending.component';

describe('ItemActiveExtendingComponent', () => {
  let component: ItemActiveExtendingComponent;
  let fixture: ComponentFixture<ItemActiveExtendingComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ItemActiveExtendingComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(ItemActiveExtendingComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
