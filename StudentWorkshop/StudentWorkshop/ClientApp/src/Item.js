import React from 'react';

import './Item.css';

export default function Item(props) {
	let val = <>{props.cost}kr</>;
	
	if (props.sale) {
		val = <><span style={{ textDecoration: 'line-through' }}>{val}</span><span style={{ color: 'red' }}> {props.sale}kr</span></>;
	}
	let className = "";
	if (props.funStuff) {
		className = "FunStuff";
	}
	return (
		<div className="Item">
			<div className={className}>
				<img alt={props.name} src={props.icon}/>
			</div>
			<p>
				<b>
					{props.name}
				</b>
			</p>
			<p>
				{val}
			</p>
			<input value="Köp" type="button" onClick={() => props.onBuy(props.name, props.sale ?? props.cost)} />
		</div>
	);
}