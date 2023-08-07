import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ItemActiveByStyleComponent } from './item-active-by-style.component';

describe('ItemActiveByStyleComponent', () => {
  let component: ItemActiveByStyleComponent;
  let fixture: ComponentFixture<ItemActiveByStyleComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ItemActiveByStyleComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(ItemActiveByStyleComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
