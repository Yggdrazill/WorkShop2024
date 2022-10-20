import React, { useState } from 'react';

import './Item.css';

import IconBitcoin from './bitcoin.png';
import IconRtx from './rtx.png';
import IconRc from './revell.jpeg';
import IconAoE4 from './aoe4.png';
import IconStiga from './stiga.jpeg';


export default function Item(props) {

	const [newCost, setNewCost] = useState(0);

	let val = <>{props.cost}kr</>;
	
	if (props.sale) {
		val = <><span style={{ textDecoration: 'line-through' }}>{val}</span><span style={{ color: 'red' }}> {props.sale}kr</span></>;
	}
	let className = "";
	if (props.funStuff) {
		className = "FunStuff";
	}
	console.log(newCost);
	
	return (
		<div className="Item">
			<div className={className}>
				<img alt={props.name} src={IdToIcon(props.imageId)}/>
			</div>
			<p>
				<b>
					{props.name}
				</b>
			</p>
			<p>
				{val}
			</p>
			{ props.onBuy != null && <input value="Köp" type="button" onClick={() => props.onBuy(props.name, props.sale ?? props.cost)} /> }
			{ props.onEdit != null && (
				<div>
					Nytt pris
					<input id={newCost} value={newCost} type="number" onChange={(input) => setNewCost(input.target.value)} /> 
				</div>
			)}
			{ props.onEdit != null && <input value="Ändra" type="button" onClick={() => props.onEdit(props.id, newCost)} /> }
		</div>
	);
}



function IdToIcon(id) {
	switch (id) {
		case 1:
			return IconAoE4;
		case 2:
			return IconStiga;
		case 3:
			return IconBitcoin;
		case 4:
			return IconRtx;
		case 5:
			return IconRc;
		default:
			return null;
	

	}

}