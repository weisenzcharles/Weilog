package org.charles.weilog.service;

import org.charles.weilog.domain.Post;
import org.charles.weilog.vo.PostQuery;
import org.springframework.data.domain.Page;
import org.springframework.data.domain.Pageable;
import org.springframework.data.jpa.repository.Query;
import org.springframework.stereotype.Service;

import java.util.List;
import java.util.Map;

@Service
public interface PostService {

    Page<Post> listPost(Pageable pageable);

    Page<Post> listPost(Pageable pageable, Post blog);

    Page<Post> listPost(Pageable pageable, PostQuery postQuery);

    Post findByAlias(String alias);

    Post insert(Post entity);

    void delete(Long id);

    Post update(Post entity);

    List<Post> findListByYear(String year);

    Map<String,List<Post>> archivePosts();

    Post findById(Long id);

    List<Post> findByPaging(String title, int pageIndex, int pageSize);

    List<Post> findByPaging(int pageIndex, int pageSize);
}