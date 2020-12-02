import React, { Component } from 'react'
import Suggestions from './Suggestions';
import axios from 'axios';
import RenderSelected from './RenderSelected';

export  interface  ObjectResult {
    id: number;
    text: string;
}


interface IState
{
    results:ObjectResult[],
    query:string,
    selected?:ObjectResult
}


class Search extends React.Component<any, IState>
{
    state = {
        query: '',
        results: [],
        selected:undefined
    }

    getInfo = async() =>
    {
        let url='http://localhost:88/api/search/';
        try {
           await axios.get(url+this.state.query)
                .then(({ data }) =>
                {
                    this.setState({results: data})
                })
        }
        catch (error) {
            console.log(error.message);
        }

    }

    handleInputChange = (e:any) =>
    {
        const query=e.target.value;
        this.setState({query:query}, () =>
        {
            if (this.state.query && this.state.query.length !==0)
            {
                if(this.state.query.length>2)
                {
                    this.getInfo()
                }
            }
            else if (!this.state.query)
            {
                this.setState({results:[], selected:undefined})
            }
        })
    }

    render()
    {
        return (
            <form className="container">
                <h3>Search App</h3>
                <input id="search-input"
                       placeholder="Search ..."
                       onChange={this.handleInputChange}/>
                {this.state.selected===undefined ?
                    <Suggestions results={this.state.results} onclickPassData={(obj)=>
                        this.setState({selected:obj})} />: <></>}

                <RenderSelected res={this.state.selected}/>
            </form>
        )
    }
}
export default Search