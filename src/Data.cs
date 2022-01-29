using System;

public class Data<T, V, C, D, E>
{
	private T t;
	private V v;
	private C c;
	private D d;
	private E e;
	public Data(T t,V v,C c,D d,E e)
	{
		this.t = t;
		this.v = v;
		this.c = c;	
		this.d = d;
		this.e = e;
	}
	public T getFirstColumn()
    {
		return t;
    }
	public V getSecondColumn()
	{
		return v;
	}
	public C getThirdColumn()
	{
		return c;
	}
	public D getFourthColumn()
	{
		return d;
	}
	public E getFiveColumn()
	{
		return e;
	}
}
